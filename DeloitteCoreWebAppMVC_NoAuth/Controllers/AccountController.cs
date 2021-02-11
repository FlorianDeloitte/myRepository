using DeloitteCoreWebAppMVC_NoAuth.Helpers;
using DeloitteCoreWebAppMVC_NoAuth.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DeloitteCoreWebAppMVC_NoAuth.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;

        public AccountController(ILogger<AccountController> logger)
        {
            _logger = logger;
        }

        // POST: /Account/Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            bool result = UserManager.Login(model.Username, model.Password);

            if (result)
            {
                return RedirectToAction("TasksList", "Home");
            }
            else
                ModelState.AddModelError("", "Invalid login attempt.");
            return View(model);
        }
    }
}