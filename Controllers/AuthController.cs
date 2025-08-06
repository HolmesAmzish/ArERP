using ArERP.Dtos;
using ArERP.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;

namespace ArERP.Controllers;

public class AuthController : Controller
{
    private readonly IUserService _userService;

    public AuthController(IUserService userService)
    {
        this._userService = userService;
    }


    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult Register(RegisterRequest request)
    {
        var result = _userService.Register(request);
        if (result == null)
            return BadRequest("User already exists");
        return Ok(result);
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult Login(LoginRequest request)
    {
        var result = _userService.Login(request);
        if (result == null)
            return Unauthorized();
        return Ok(result);
    }
    
    [HttpGet("/api/auth/GetUsername")] [Authorize]
    public IActionResult GetUsername()
    {
        var username = User.Identity?.Name;
        return Ok($"Hello, {username}");
    }
}
