using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

using CareerOrientation.Application.Auth.Common;
using CareerOrientation.Application.Common.Abstractions.Auth;
using CareerOrientation.Application.Common.Abstractions.Services;
using CareerOrientation.Domain.Entities;
using CareerOrientation.Infrastructure.Common.Options;

using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace CareerOrientation.Infrastructure.Auth;

public class JwtService : ITokenCreationService
{
    private DateTime _creationDateTime;

    private readonly JwtOptions _jwtOptions;
    private readonly IClock _clock;

    public JwtService(IOptions<JwtOptions> jwtOptions, IClock clock)
    {
        _jwtOptions = jwtOptions.Value;
        _clock = clock;
    }

    public AuthenticationResult CreateToken(User user)
    {
        _creationDateTime = _clock.UtcNow;
        var expiration = _creationDateTime.Add(_jwtOptions.ExpirationTime);

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
            issuer: _jwtOptions.Issuer,
            audience: _jwtOptions.Audience,
            claims: claims,
            notBefore: _creationDateTime,
            expires: expirationDateTime,
            signingCredentials: credentials
        );

    // TODO: Add roles and their corresponding non secret claims
    private Claim[] CreateClaims(User user) =>
        new[] {
            new Claim(JwtRegisteredClaimNames.Sub, _jwtOptions.Subject),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Iat, _creationDateTime.Ticks.ToString()),
            new Claim("userId", user.Id),
            new Claim(ClaimTypes.Name, user.UserName!),
            new Claim(ClaimTypes.Email, user.Email!)
        };

    private SigningCredentials CreateSigningCredentials() =>
        new SigningCredentials(
            new SymmetricSecurityKey(
                Encoding.ASCII.GetBytes(_jwtOptions.Key)
            ),
            SecurityAlgorithms.HmacSha256
        );
}
