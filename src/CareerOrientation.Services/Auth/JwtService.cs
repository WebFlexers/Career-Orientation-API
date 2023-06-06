using CareerOrientation.Data.DTOs;
using CareerOrientation.Data.Entities;
using CareerOrientation.Services.Auth.Abstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CareerOrientation.Services.Auth;

public class JwtService : ITokenCreationService
{
    private readonly int ExpirationMinutes;
    private DateTime _creationDateTime;

    private readonly IConfiguration _configuration;

    public JwtService(IConfiguration configuration)
    {
        _configuration = configuration;
        ExpirationMinutes = int.Parse(configuration["Jwt:ExpirationMinutes"]!);
    }

    public AuthenticationResponse CreateToken(User user)
    {
        _creationDateTime = DateTime.UtcNow;
        var expiration = _creationDateTime.AddMinutes(ExpirationMinutes);

        var token = CreateJwtToken(
            CreateClaims(user),
            CreateSigningCredentials(),
            expiration
        );

        var tokenHandler = new JwtSecurityTokenHandler();

        return new AuthenticationResponse
        {
            Token = tokenHandler.WriteToken(token),
            Expiration = expiration
        };
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
