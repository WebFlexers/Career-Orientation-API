using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

using CareerOrientation.Application.Auth.Common;
using CareerOrientation.Application.Common.Abstractions.Auth;
using CareerOrientation.Application.Common.Abstractions.Services;
using CareerOrientation.Domain.Entities;

using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace CareerOrientation.Infrastructure.Auth;

public class JwtService : ITokenCreationService
{
    private readonly int ExpirationMinutes;
    private DateTime _creationDateTime;

    private readonly IConfiguration _configuration;
    private readonly IClock _clock;

    public JwtService(IConfiguration configuration, IClock clock)
    {
        _configuration = configuration;
        _clock = clock;
        ExpirationMinutes = int.Parse(configuration["Jwt:ExpirationMinutes"]!);
    }

    public AuthenticationResult CreateToken(User user)
    {
        _creationDateTime = _clock.UtcNow;
        var expiration = _creationDateTime.AddMinutes(ExpirationMinutes);

        var token = CreateJwtToken(
            CreateClaims(user),
            CreateSigningCredentials(),
            expiration
        );

        var tokenHandler = new JwtSecurityTokenHandler();

        return new AuthenticationResult
        (
            UserId: user.Id,
            Token: tokenHandler.WriteToken(token),
            Expiration: expiration
        );
    }

    private JwtSecurityToken CreateJwtToken(Claim[] claims, SigningCredentials credentials, DateTime expirationDateTime) =>
        new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            notBefore: _creationDateTime,
            expires: expirationDateTime,
            signingCredentials: credentials
        );

    // TODO: Add roles and their corresponding non secret claims
    private Claim[] CreateClaims(User user) =>
        new[] {
            new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]!),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Iat, _creationDateTime.ToString()),
            new Claim(ClaimTypes.NameIdentifier, user.Id),
            new Claim(ClaimTypes.Name, user.UserName!),
            new Claim(ClaimTypes.Email, user.Email!)
        };

    private SigningCredentials CreateSigningCredentials() =>
        new SigningCredentials(
            new SymmetricSecurityKey(
                Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]!)
            ),
            SecurityAlgorithms.HmacSha256
        );
}
