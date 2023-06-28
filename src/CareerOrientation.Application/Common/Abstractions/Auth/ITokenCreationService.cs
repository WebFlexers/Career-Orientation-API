using CareerOrientation.Application.Auth.Common;
using CareerOrientation.Domain.Entities;

namespace CareerOrientation.Application.Common.Abstractions.Auth;

public interface ITokenCreationService
{
    AuthenticationResult CreateToken(User user);
}