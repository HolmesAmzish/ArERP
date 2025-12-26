using ArERP.Dtos;
using ArERP.Service;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using System.Security.Claims;

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
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var result = _userService.Register(request);
        if (result == null)
            return BadRequest("User already exists");

        // Sign in the user
        var user = _userService.GetUserByUsername(request.Username);
        if (user != null)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };
            var claimsIdentity = new ClaimsIdentity(claims, "Cookies");
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            await HttpContext.SignInAsync("Cookies", claimsPrincipal);
        }

        return RedirectToAction("Login");
    }

    [HttpGet]
    public IActionResult Login()
    {
        if (User.Identity?.IsAuthenticated == true)
        {
            return RedirectToAction("Dashboard", "Home");
        }
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var result = _userService.Login(request);
        if (result == null)
            return Unauthorized();

        // Sign in the user
        var user = _userService.GetUserByUsername(request.Username);
        if (user != null)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };
            var claimsIdentity = new ClaimsIdentity(claims, "Cookies");
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            await HttpContext.SignInAsync("Cookies", claimsPrincipal);
        }

        return RedirectToAction("Dashboard", "Home");
    }
    
    [HttpPost]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync("Cookies");
        return RedirectToAction("Index", "Home");
    }

    [HttpGet("/api/auth/GetUsername")] [Authorize]
    public IActionResult GetUsername()
    {
        var username = User.Identity?.Name;
        return Ok($"Hello, {username}");
    }
}
