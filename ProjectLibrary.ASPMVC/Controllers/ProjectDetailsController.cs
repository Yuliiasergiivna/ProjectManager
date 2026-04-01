using Microsoft.AspNetCore.Mvc;
using ProjectLibrary.ASPMVC.Handlers;
using ProjectLibrary.ASPMVC.Mappers;
using ProjectLibrary.ASPMVC.Models.Projects;
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
            var projects = _projectService.GetProjectsByManagerId(id);
            if (projects == null || !projects.Any())
            {
                return View(new List<ProjectViewModel>());
            }
            var employee = _employeeService.GetById(id);
            ViewBag.EmployeeName = employee?.LastName;

            var projectViewModels = projects.Select(p => {
                var manager = _employeeService.GetById(p.ProjectManagerId);
            string managerName = manager != null ?
             $"{manager?.FirstName} {manager?.LastName}" : "Inconnu";
            return Mappers.Mapper.ToProjectViewModel(p, managerName);
                }).ToList();
            return View(projectViewModels);
        }
        public IActionResult Details(Guid id)
        {
            var project = _projectService.GetProjectById(id);
            if (project == null)
            {
                return NotFound();
            }
            bool isProjectManager = _userSessionManager.IsProjectManager ||project.ProjectManagerId ==GetCurrentUserId();
            var employees = _employeeService.GetProjectMembers(id)?.ToList() ?? new List<BLL.Entities.Employee>();
            var posts = _postService.GetPostsByProjectManager(id)?.ToList() ?? new List<BLL.Entities.Post>();
            var currentUserId = _userSessionManager.IsProjectManager;
            //var postViewModels = posts.Select(p => p.ToPostViewModel(employees)).ToList();
            var viewModel = Mappers.Mapper.ToProjectDetailsViewModel(
                project,
                employees,
                posts, 
                isProjectManager);

            return View(viewModel);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(ProjectCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var newProject = new BLL.Entities.Project(
                    Guid.NewGuid(), 
                    model.Name, 
                    model.Description,
                    DateTime.Now, 
                    GetCurrentUserId());
                _projectService.AddProject(newProject);
                return RedirectToAction("Index", new { id = newProject.ProjectId});
            }

            return View(model);
        }
    }
}
