using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ArERP.Dtos;
using ArERP.Enum;
using ArERP.Models;
using ArERP.Repository;
using Microsoft.IdentityModel.Tokens;

namespace ArERP.Service.Impl;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IConfiguration _configuration;

    public UserService(IUserRepository userRepository, IConfiguration configuration)
    {
        this._userRepository = userRepository;
        this._configuration = configuration;
    }

    public List<User> GetAllUsers() => _userRepository.GetAllUsers();

    public User? GetUserById(int id) => _userRepository.GetUserById(id);

    public AuthResponse Login(LoginRequest request)
    {
        var user = _userRepository.GetUserByUsername(request.Username);
        if (user == null) return null;
        if (!BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
            return null;

        var token = GenerateJwt(user);
        return new AuthResponse { StatusCode = (int)ResponseStatus.Ok, Token = token };
        
    }
    
    public AuthResponse Register(RegisterRequest request)
    {
        var existing = _userRepository.GetUserByUsername(request.Username);
        if (existing != null) return null;

        var newUser = new User
        {
            Username = request.Username,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password)
        };

        _userRepository.AddUser(newUser);
        var token = GenerateJwt(newUser);
        return new AuthResponse { StatusCode = (int)ResponseStatus.Ok, Token = token };
    }
    
    private string GenerateJwt(User user)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
        };

        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddHours(1),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}