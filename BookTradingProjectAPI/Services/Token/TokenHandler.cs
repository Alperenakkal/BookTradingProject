using BookTradingProjectAPI.Dtos.Token;
using BookTradingProjectAPI.Services.Token;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

public class TokenHandler : ITokenHandler
{
    private readonly JwtSettings _jwtSettings;

    public TokenHandler(IOptions<JwtSettings> jwtSettings)
    {
        _jwtSettings = jwtSettings.Value;
    }

    public Token CreateAccessToken(int minutes)
    {
        Token token = new();

        // Use the key from JwtSettings
        SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(_jwtSettings.Key));

        // Create signing credentials with the symmetric key and algorithm
        SigningCredentials signingCredentials = new(securityKey, SecurityAlgorithms.HmacSha256);

        // Set token expiration
        token.Expiration = DateTime.UtcNow.AddMinutes(minutes);

        // Create the JWT token
        JwtSecurityToken securityToken = new(
            audience: _jwtSettings.Audience,
            issuer: _jwtSettings.Issuer,
            expires: token.Expiration,
            notBefore: DateTime.UtcNow,
            signingCredentials: signingCredentials
        );

        // Write the token
        JwtSecurityTokenHandler tokenHandler = new();
        token.AccessToken = tokenHandler.WriteToken(securityToken);

        return token;
    }
}
