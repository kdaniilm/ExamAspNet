using ExamAspNet.Infrastructure.Interfaces;
using ExamAspNet.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamAspNet.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly IEmailSender _emailSender;
        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<Role> roleManager, IEmailSender emailSender)
        {
            this._signInManager = signInManager;
            this._userManager = userManager;
            this._roleManager = roleManager;
            this._emailSender = emailSender;
        }

        [HttpGet]
        public async Task<IActionResult> Register(string returnUrl = "") => await Task.Run(() => View());

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model, string returnUrl = "")
        {
            if (!TryValidateModel(model)) return StatusCode(500);

            var user = new User() { Email = model.Email, UserName = model.Email };
            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded) return StatusCode(500);

            if (await _roleManager.FindByNameAsync("user") == null)
            {
                var role = await _roleManager.CreateAsync(new Role() { Name = "user" });
                if (role.Succeeded)
                    await _userManager.AddToRoleAsync(user, "user");
            }
            else await _userManager.AddToRoleAsync(user, "user");

            await _signInManager.SignInAsync(user, false);

            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var link = Url.Action("Confirm", "Account",
                new { guid = token, userEmail = user.Email }, Request.Scheme, Request.Host.Value);
            await _emailSender.SendEmailAsync(user.Email, "Confirm your email ->>>", link);

            return Redirect("/home/index");

        }

        [HttpGet]
        public async Task<IActionResult> Login(string returnUrl = "") => await Task.Run(() => View());

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = "")
        {
            if (!TryValidateModel(model)) return StatusCode(500);

            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            return StatusCode(500);

        }


        [HttpGet]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Logout(string returnUrl = "")
        {
            await _signInManager.SignOutAsync();

            if (returnUrl == "/")
                return RedirectToAction("Index", "Home");

            else if (Url.IsLocalUrl(returnUrl))
                return Redirect(returnUrl);

            return new EmptyResult();

        }

        [HttpGet]
        public async Task<IActionResult> ConfirmAsync(string guid, string userEmail)
        {
            var user = await _userManager.FindByEmailAsync(email: userEmail);
            var res = await _userManager.ConfirmEmailAsync(user, guid);
            if (res.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            //todo add ERROR PAGE
            return View();
        }
    }
}
