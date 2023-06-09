using CareerOrientation.Data.DTOs.Auth;
using CareerOrientation.Data.Entities.Users;

namespace CareerOrientation.Services.Auth.Abstractions;

public interface ITokenCreationService
{
    AuthenticationResponse CreateToken(User user);
}