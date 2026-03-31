using Microsoft.AspNetCore.Mvc;
using ProjectLibrary.BLL.Services;

namespace ProjectLibrary.ASPMVC.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeService _employeeService;

        public EmployeeController(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public IActionResult Index()
        {
            var employees = _employeeService.GetAvailableEmployees();

            return View(employees);
        }
    }
}
