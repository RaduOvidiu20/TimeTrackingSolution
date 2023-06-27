using Core.Contracts;
using Core.Enums;
using Core.IdentityEntities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TimeTracking.Web.Controllers;

[Route("[controller]")]
public class AccountController : Controller
{
    private readonly RoleManager<ApplicationRole> _roleManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IEmployee _employee;

    public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,
        RoleManager<ApplicationRole> roleManager, IEmployee employee)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _roleManager = roleManager;
        _employee = employee;
    }

    [AllowAnonymous]
    [HttpGet]
    [Route("[action]")]
    public async Task<IActionResult> Register()
    {
        var employees = await _employee.GetAllEmployees();

        ViewBag.Employees = employees.Select(e => new SelectListItem
            { Text = e.Name, Value = e.EmployeeId.ToString() }).ToList();

        return View();
    }


    [HttpPost]
    [Authorize]
    [Route("[action]")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(RegisterDto registerDto)
    {
        //Check for validation errors
        if (ModelState.IsValid == false)
        {
            ViewBag.Errors = ModelState.Values.SelectMany(temp => temp.Errors).Select(temp => temp.ErrorMessage);
            return View(registerDto);
        }

        var user = new ApplicationUser
        {
            UserName = registerDto.UserName,
            PersonName = registerDto.UserName,
            Employee = registerDto.UserEmployee
        };

        var result = await _userManager.CreateAsync(user, registerDto.Password);
        if (result.Succeeded)
        {
            //Check status of radio button
            if (registerDto.UserType == UserType.Admin)
            {
                //Create 'Admin' role
                if (await _roleManager.FindByNameAsync(UserType.Admin.ToString()) is null)
                {
                    var applicationRole = new ApplicationRole { Name = UserType.Admin.ToString() };
                    await _roleManager.CreateAsync(applicationRole);
                }

                //Add the new user into 'Admin' role
                await _userManager.AddToRoleAsync(user, UserType.Admin.ToString());
            }
            else
            {
                //Create 'Admin' role
                if (await _roleManager.FindByNameAsync(UserType.User.ToString()) is null)
                {
                    var applicationRole = new ApplicationRole { Name = UserType.User.ToString() };
                    await _roleManager.CreateAsync(applicationRole);
                }

                //Add the new user into 'User' role
                await _userManager.AddToRoleAsync(user, UserType.User.ToString());
            }

            //Sign in
            await _signInManager.SignInAsync(user, false);

            return RedirectToAction("Index", "Home");
        }

        foreach (var error in result.Errors) ModelState.AddModelError("Register", error.Description);

        return View(registerDto);
    }


    [HttpGet]
    [AllowAnonymous]
    [Route("[action]")]
    public IActionResult Login()
    {
        return View();
    }


    [HttpPost]
    [AllowAnonymous]
    [Route("[action]")]
    public async Task<IActionResult> Login(LoginDto loginDto, string? returnUrl)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.Errors = ModelState.Values.SelectMany(temp => temp.Errors).Select(temp => temp.ErrorMessage);
            return View(loginDto);
        }

        var result = await _signInManager.PasswordSignInAsync(loginDto.UserName!, loginDto.Password!, false, false);

        if (result.Succeeded)
        {
            if (loginDto.UserName != null)
            {
                var user = await _userManager.FindByEmailAsync(loginDto.UserName);
                if (user != null)
                    if (await _userManager.IsInRoleAsync(user, UserType.Admin.ToString()))
                        return RedirectToAction("Index", "Home");
            }

            if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl)) return LocalRedirect(returnUrl);
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
       
        ModelState.AddModelError("Login", "Invalid email or password");
        return View(loginDto);
    }


    [Authorize]
    [Route("[action]")]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction(nameof(HomeController.Index), "Home");
    }
}