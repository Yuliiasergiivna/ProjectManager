using Microsoft.AspNetCore.Mvc;
using ProjectLibrary.ASPMVC.Handlers;
using ProjectLibrary.BLL.Services;

namespace ProjectLibrary.ASPMVC.Controllers
{
    public class ProjectDetailsController : Controller
    {
        private readonly ProjectService _projectService;
        private readonly EmployeeService _employeeService;
        private readonly PostService _postService;
        private readonly UserSessionManager _userSessionManager;

        public ProjectDetailsController(ProjectService projectService, EmployeeService employeeService, PostService postService, UserSessionManager userSessionManager)
        {
            _projectService = projectService;
            _employeeService = employeeService;
            _postService = postService;
            _userSessionManager = userSessionManager;
        }
        private Guid GetCurrentUserId() 
        { 
            return _userSessionManager.UserId ?? Guid.Empty;
        }

        public IActionResult Index(Guid id)
        {
            var projects = _projectService.GetProjectsByEmployeeId(id);
            if (projects == null || !projects.Any()) 
            {
                return View(new List<ProjectLibrary.BLL.Entities.Project>());
            }
            var employee = _employeeService.GetById(id);
            ViewBag.EmployeeName = employee?.LastName;
            return View(projects);
        }
        public IActionResult Details(Guid id)
        {
            var project = _projectService.GetProjectById(id);
            if (project == null)
            {
                return NotFound();
            }
            bool isProjectManager = _userSessionManager.IsProjectManager ||project.ProjectManagerId ==GetCurrentUserId();
            var employees = _employeeService.GetProjectMembers(id);
            var posts = _postService.GetPostsByProjectManager(id);
            ViewBag.Employees = employees;
            ViewBag.Posts = posts;
            ViewBag.IsProjectManager = isProjectManager;

            return View(project);
        }
    }
}
