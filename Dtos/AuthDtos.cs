using ArERP.Enum;

namespace ArERP.Dtos;

public class LoginRequest 
{
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}

public class RegisterRequest
{
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}

public class AuthResponse
{
    public int StatusCode { get; set; }
    public string Token { get; set; } = string.Empty;
}
