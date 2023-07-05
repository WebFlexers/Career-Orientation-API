using CareerOrientation.Application.Auth.Common;
using CareerOrientation.Application.Common.Abstractions.Auth;
using CareerOrientation.Application.Common.Abstractions.Persistence;
using CareerOrientation.Application.Common.Abstractions.Services;
using CareerOrientation.Application.Common.Logging;
using CareerOrientation.Domain.Common.DomainErrors;
using CareerOrientation.Domain.Entities;

using ErrorOr;

using MediatR;

using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace CareerOrientation.Application.Auth.Commands.Register;

public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, ErrorOr<AuthenticationResult>>
{
    private readonly ILogger<RegisterUserCommandHandler> _logger;
    private readonly IUserRepository _userRepository;
    private readonly ITrackRepository _trackRepository;
    private readonly UserManager<User> _userManager;
    private readonly IRoleManagerService _roleManagerService;
    private readonly ITokenCreationService _tokenCreationService;

    public RegisterUserCommandHandler(ILogger<RegisterUserCommandHandler> logger, IUserRepository userRepository,
        ITrackRepository trackRepository, UserManager<User> userManager, IRoleManagerService roleManagerService,
        ITokenCreationService tokenCreationService)
    {
        _logger = logger;
        _userRepository = userRepository;
        _trackRepository = trackRepository;
        _userManager = userManager;
        _roleManagerService = roleManagerService;
        _tokenCreationService = tokenCreationService;
    }
    
    public async Task<ErrorOr<AuthenticationResult>> Handle(
        RegisterUserCommand command, 
        CancellationToken cancellationToken)
    {
        // Begin a transaction to rollback the user creation if the role assignment fails
        await _userRepository.BeginTransactionAsync(cancellationToken);

        try
        {
            var newUser = new User()
            {
                UserName = command.Username,
                Email = command.Email,
                IsProspectiveStudent = command.IsProspectiveStudent,
            };
        
            var userCreationResult = await _userManager.CreateAsync(
                newUser,
                command.Password
            );

            if (userCreationResult.Succeeded == false)
            {
                return userCreationResult.Errors
                    .Select(identityError => Error.Validation(
                        code: identityError.Code, 
                        description: identityError.Description)
                    ).ToArray();
            }

            if (command.IsProspectiveStudent == false)
            {
                Track? track = null;

                if (command.Semester >= 5)
                {
                    track = await _trackRepository.GetTrackByName(command.Track);
                    if (track is null)
                    {
                        return Errors.Tracks.NonExistentTrack;
                    }
                }

                var student = new UniversityStudent()
                {
                    UserId = newUser.Id,
                    IsGraduate = command.IsGraduate,
                    Semester = command.Semester,
                    TrackId =  track?.TrackId
                };

                await _userRepository.AddUniversityStudent(student);
            }
            
            var roleAddResult = await _roleManagerService.AddUserToRole(command, newUser);

            return await roleAddResult.MatchAsync<ErrorOr<AuthenticationResult>>(async role =>
            {
                await _userRepository.CommitTransactionAsync(default);
                _logger.LogSuccessfulUserInsertion(newUser.Id, role);
                return _tokenCreationService.CreateToken(newUser);
            }, async errors =>
            {
                await _userRepository.RollbackTransactionAsync();
                return errors;
            });
        }
        catch
        {
            await _userRepository.RollbackTransactionAsync();
            throw;
        }
    }
}