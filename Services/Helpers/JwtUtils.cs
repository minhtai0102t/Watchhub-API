using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Ecom_API.DTO.Entities;
using Services.CommonConfig;
using Microsoft.Extensions.Options;
using Ecom_API.DTO.Models;

namespace Ecom_API.Authorization;

public interface IJwtUtils
{
    string GenerateToken(User user);
    int ValidateToken(string token);
    GoogleUser ValidateGoogleToken(string token);
}
public class JwtUtils : IJwtUtils
{
    private readonly AppSettings _appSettings;

    public JwtUtils(IOptions<AppSettings> appSettings)
    {
        _appSettings = appSettings.Value;
    }

    public string GenerateToken(User user)
    {
        // generate token that is valid for 7 days
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
        var claimIdentity = new ClaimsIdentity();
        claimIdentity.AddClaim(new Claim("id", user.id.ToString()));
        claimIdentity.AddClaim(new Claim("username", user.username == null ? "" : user.username));
        claimIdentity.AddClaim(new Claim("fullname", user.fullname));
        claimIdentity.AddClaim(new Claim("email", user.email));
        claimIdentity.AddClaim(new Claim("avatar", user.avatar == null ? "" : user.avatar));
        claimIdentity.AddClaim(new Claim("phone", user.phone == null ? "" : user.phone));
        claimIdentity.AddClaim(new Claim("created_date", user.created_date.ToString()));
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = claimIdentity,
            Expires = DateTime.Now.AddDays(7),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    public int ValidateToken(string token)
    {
        if (token == null)
            return -1;

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
        try
        {
            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                ClockSkew = TimeSpan.Zero
            }, out SecurityToken validatedToken);

            var jwtToken = (JwtSecurityToken)validatedToken;
            int userId = int.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);
            // return user id from JWT token if validation successful
            return userId;
        }
        catch
        {
            // return null if validation fails
            return -1;
        }
    }
    public GoogleUser ValidateGoogleToken(string token)
    {
        if (token == null)
            return null;

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
        try
        {
            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                ClockSkew = TimeSpan.Zero
            }, out SecurityToken validatedToken);

            var jwtToken = (JwtSecurityToken)validatedToken;
            string name = jwtToken.Claims.First(x => x.Type == "name").Value;
            string picture = jwtToken.Claims.First(x => x.Type == "picture").Value;
            string userId = jwtToken.Claims.First(x => x.Type == "user_id").Value;
            string email = jwtToken.Claims.First(x => x.Type == "email").Value;
            // return user id from JWT token if validation successful
            return new GoogleUser{
                name = name,
                picture = picture,
                user_id = userId,
                email = email
            };
        }
        catch (Exception ex)
        {
            // return null if validation fails
            return null;
        }
    }
}

