using ArERP.Dtos;
using ArERP.Models;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;

namespace ArERP.Service;

public interface IUserService
{
    List<User> GetAllUsers();
    User? GetUserById(int id);
    AuthResponse Login(LoginRequest request);
    AuthResponse Register(RegisterRequest request);
}