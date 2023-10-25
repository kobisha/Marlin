// AuthController.cs
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Marlin.sqlite.Data;
using Marlin.sqlite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly DataContext _context;

    public AuthController(IConfiguration configuration, DataContext context)
    {
        _configuration = configuration;
        _context = context;
    }

    [HttpPost("login")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public IActionResult Login(LoginModel loginModel)
    {
        if (!IsValidLogin(loginModel.Username, loginModel.Password))
        {
            return Unauthorized();
        }

        var token = GenerateJwtToken(loginModel.Username);

        return Ok(new { Token = token });
    }

    private bool IsValidLogin(string username, string password)
    {
        var user = _context.Users.FirstOrDefault(u => u.Email == username);

        if (user == null)
        {
            return false;
        }

        if (user.Password == password)
        {
            return true;
        }

        return false;
    }

   /* private bool VerifyPassword(string password, string hashedPassword)
    {
        // Implement your password verification logic here
        // Compare the provided password with the hashed password using a secure hashing algorithm

        // Example using System.Security.Cryptography
        using var sha256 = SHA256.Create();
        var hashedInputBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

        // Convert the hashed password from bytes to string
        var hashedInput = BitConverter.ToString(hashedInputBytes).Replace("-", "");

        // Compare the hashed password with the stored hashed password
        return hashedInput.Equals(hashedPassword, StringComparison.OrdinalIgnoreCase);
    }*/

    private string GenerateJwtToken(string username)
    {
        var jwtConfig = _configuration.GetSection("Jwt");
        var secretKey = jwtConfig["SecretKey"];
        var issuer = jwtConfig["Issuer"];
        var audience = jwtConfig["Audience"];
        var expiryInMinutes = Convert.ToInt32(jwtConfig["ExpiryInMinutes"]);

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(ClaimTypes.Name, username)
        };

        var token = new JwtSecurityToken(
            issuer,
            audience,
            claims,
            expires: DateTime.UtcNow.AddMinutes(expiryInMinutes),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
