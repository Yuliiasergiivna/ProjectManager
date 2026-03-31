using ProjectLibrary.Common.Repositories;
using ProjectLibrary.DAL.Entities;
using ProjectLibrary.BLL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ProjectLibrary.BLL.Mappers;

namespace ProjectLibrary.BLL.Services
{
    public class ProjectService
    {
        private readonly IProjectRepository<DAL.Entities.Project> _projectRepository;

        public ProjectService(IProjectRepository<DAL.Entities.Project> projectRepository)
        {
            _projectRepository = projectRepository;
        }
        public IEnumerable<BLL.Entities.Project> GetProjectsByEmployeeId(Guid employeeId)
        {
            return _projectRepository.GetProjectsByEmployeeId(employeeId).Select(p => p.ToProject());
        }
        public IEnumerable<BLL.Entities.Project> GetProjectsByManagerId(Guid managerId)
        {
            return _projectRepository.GetProjectsByManagerId(managerId).Select(p => p.ToProject());
        }
        public BLL.Entities.Project? GetProjectById(Guid id)
        {
            var dalProject = _projectRepository.GetProjectById(id);
            return dalProject?.ToProject();
        }
        public void AddProject(BLL.Entities.Project project)
        {
            _projectRepository.AddProject(project.ToDalProject());
        }
        public void UpdateProject(BLL.Entities.Project project)
        {
            _projectRepository.UpdateProject(project.ToDalProject());
        }
        public void AddMember(Guid projectId, Guid employeeId)
        {
            _projectRepository.AddMember(projectId, employeeId);
        }
        public void RemoveMember(Guid projectId, Guid employeeId)
        {
            _projectRepository.RemoveMember(projectId, employeeId);
        }
    }
}
