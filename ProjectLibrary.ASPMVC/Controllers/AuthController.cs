using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using ProjectLibrary.BLL.Services;
using ProjectLibrary.ASPMVC.Handlers;

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
        public IActionResult Login(string email, string password)
        {
            var user = _authService.CheckPassword(email, password);
            if (user != null)
            {
                _userSessionManager.UserId = user.EmployeeId;
                    _userSessionManager.IsProjectManager = user.IsProjectManager;

                return RedirectToAction("Index", "ProjectDetails");
            }
            return View();
        }
        public IActionResult Index()
        {
            return RedirectToAction("Login");
        }
    }
}
