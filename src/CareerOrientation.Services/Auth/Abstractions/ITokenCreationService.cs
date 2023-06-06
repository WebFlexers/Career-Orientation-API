using CareerOrientation.Data.DTOs;
using CareerOrientation.Data.Entities;

namespace CareerOrientation.Services.Auth.Abstractions;

public interface ITokenCreationService
{
    AuthenticationResponse CreateToken(User user);
}