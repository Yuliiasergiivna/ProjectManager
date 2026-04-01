using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using ProjectLibrary.ASPMVC.Handlers;
using ProjectLibrary.ASPMVC.Models;
using ProjectLibrary.BLL.Services;
using ProjectLibrary.DAL.Services;

namespace ProjectLibrary.ASPMVC.Controllers
{
    public class AuthController : Controller
    {
        private readonly AuthService _authService;
        private readonly UserSessionManager _userSessionManager;

        public AuthController(AuthService authService, UserSessionManager userSessionManager)
        {
            _authService = authService;
            _userSessionManager = userSessionManager;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
           if (ModelState.IsValid)
           {
               var user = _authService.CheckPassword(model.Email, model.Password);

                if (user != null)
              {
                   _userSessionManager.UserId = user.EmployeeId;
                   _userSessionManager.IsProjectManager = user.IsProjectManager;


                   return RedirectToAction("Index", "ProjectDetails", new { id = user.EmployeeId });
                }
                 ModelState.AddModelError(string.Empty, "Email ou mot de passe incorrect.");
                return RedirectToAction("Details", "ProjectDetails");

                }
                 return View(model);
            }
            public IActionResult Index()
        {
           return RedirectToAction("Login");
        }

    }
}
