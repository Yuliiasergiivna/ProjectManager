using ProjectLibrary.BLL.Entities;
using ProjectLibrary.ASPMVC.Models;
using ProjectLibrary.BLL.Services;
using Newtonsoft.Json;
using ProjectLibrary.ASPMVC.Models.Projects;

namespace ProjectLibrary.ASPMVC.Mappers
{
    public static class Mapper
    {
       public  static EmployeeViewModel ToEmployeeViewModel(this Employee employee)
        {
            if (employee == null)
                return null;

            return new EmployeeViewModel
            {
                EmployeeId = employee.EmployeeId,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Email = employee.Email,
                IsProjectManager = employee.IsProjectManager
            };
        }
        public static PostViewModel ToPostViewModel( this Post post, IEnumerable<Employee> employees)
        {
                if (post == null)
                    return null;
                var author = employees.FirstOrDefault(m => m.EmployeeId == post.EmployeeId);
            return new PostViewModel
            {
                PostId = post.PostId,
                Content = post.Content,
                SendDate = post.SendDate,
                EmployeeId = post.EmployeeId,
                ProjectId = post.ProjectId,
                AuthorName= author != null ? $"{author.FirstName} {author.LastName}" : "Unconnu"
            };
        }
        public static ProjectDetailsViewModel ToProjectDetailsViewModel(Project project, List<Employee> members, List<Post> posts, bool isProjectManager)
            {
            if (project == null)
                    return null;
            return new ProjectDetailsViewModel
                {
                    ProjectId = project.ProjectId,
                    Name = project.Name,
                    Description = project.Description,
                    CreationDate = project.CreationDate,
                Membres = members.Select(m => ToEmployeeViewModel(m)).ToList(),
                    Posts = posts.Select(p => p.ToPostViewModel(members)).ToList(),
                    isProjectManager = isProjectManager
                };
        }
        public static ProjectViewModel ToProjectViewModel(this Project project, string managerName)
            {
                if (project == null)
                    return null;
                return new ProjectViewModel
                    {
                        ProjectId = project.ProjectId,
                        Name = project.Name,
                        Description = project.Description,
                        CreationDate = project.CreationDate,
                        ManagerName = managerName
                    };
        }
    }
}
