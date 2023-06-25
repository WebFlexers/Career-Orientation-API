using CareerOrientation.Data;
using CareerOrientation.Data.DTOs.Auth;
using CareerOrientation.Data.Entities.Users;
using CareerOrientation.Services.Auth;
using CareerOrientation.Services.Auth.Abstractions;
using CareerOrientation.Services.Common;
using CareerOrientation.Services.Mediator.Commands.Auth;
using CareerOrientation.Services.Validation.Exceptions;
using FluentValidation;
using LanguageExt.Common;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CareerOrientation.Services.Mediator.Handlers.Auth;

public class CreateUserHandler : IRequestHandler<CreateUserCommand, Result<AuthenticationResponse>>
{
    private readonly ILogger<CreateUserHandler> _logger;
    private readonly IValidator<CreateUserRequest> _validator;
    private readonly ApplicationDbContext _dbContext;
    private readonly UserManager<User> _userManager;
    private readonly IRoleManagerService _roleManagerService;
    private readonly ITokenCreationService _tokenCreationService;

    public CreateUserHandler(ILogger<CreateUserHandler> logger, IValidator<CreateUserRequest> validator, 
        ApplicationDbContext dbContext, UserManager<User> userManager, IRoleManagerService roleManagerService, 
        ITokenCreationService tokenCreationService)
    {
        _logger = logger;
        _validator = validator;
        _dbContext = dbContext;
        _userManager = userManager;
        _roleManagerService = roleManagerService;
        _tokenCreationService = tokenCreationService;
    }

    public async Task<Result<AuthenticationResponse>> Handle(CreateUserCommand command, 
        CancellationToken cancellationToken)
    {
        var createRequest = command.CreateUserRequest;

        var validationResult = await _validator.ValidateAsync(createRequest, cancellationToken);

        IdentityException? exception = null;
        if (validationResult.IsValid == false)
        {
            exception = validationResult.MapToIdentityException()!;
        }

        // Begin a transaction to rollback the user creation if the role assignment fails
        await using var transaction = await _dbContext.Database.BeginTransactionAsync(cancellationToken);

        var newUser = new User()
        {
            UserName = createRequest.Username,
            Email = createRequest.Email,
            IsProspectiveStudent = createRequest.IsProspectiveStudent,
        };

        var userCreationResult = await _userManager.CreateAsync(
            newUser,
            createRequest.Password
        );

        if (userCreationResult.Succeeded == false)
        {
            if (exception is null) 
            {
                exception = new IdentityException(userCreationResult.Errors);
            }
            else
            {
                exception.Errors = exception.Errors.Concat(userCreationResult.Errors);
            }
        }

        if (createRequest.IsProspectiveStudent == false)
        {
            // Add the extra information that is not registered with the identity CreateAsync method
            try
            {
                var track = await _dbContext.Tracks.FirstOrDefaultAsync(track => track.Name == createRequest.Track);
            
                var student = new UniversityStudent()
                {
                    UserId = newUser.Id,
                    IsGraduate = createRequest.IsGraduate,
                    Semester = createRequest.Semester,
                    TrackId =  track?.TrackId
                };

                await _dbContext.UniversityStudents.AddAsync(student);

                await _dbContext.SaveChangesAsync();
                
                _logger.LogSuccessfullStudentInsertion(newUser.Id);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                _logger.LogFailedDatabaseOperation(ex);
                return new Result<AuthenticationResponse>(ex);
            }
        }

        if (exception is not null)
        {
            await transaction.RollbackAsync();
            _logger.LogValidationFail(nameof(createRequest));
            return new Result<AuthenticationResponse>(exception);
        }

        createRequest.Password = null;
        createRequest.ConfirmPassword = null;

        _logger.LogSuccessfulUserInsertion(newUser.Id);

        var roleAddResult = await _roleManagerService.AddUserToRole(createRequest, newUser);

        return roleAddResult.Match(
            role => { 
                _logger.LogSuccessfulRoleAssignment(newUser.Id, role);
                transaction.Commit();
                return _tokenCreationService.CreateToken(newUser);
            },
            ex => { 
                _logger.LogFailedRoleAssignment(newUser.Id);
                transaction.Rollback();
                return new Result<AuthenticationResponse>(ex);
            }
        );
    }
}
