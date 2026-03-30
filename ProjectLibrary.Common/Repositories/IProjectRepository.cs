
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectLibrary.Common.Repositories
{
    public interface IProjectRepository<TProject>
    {
  
        IEnumerable<TProject> GetProjectsByEmployeeId(Guid employeeId);
        IEnumerable<TProject> GetProjectsByManagerId(Guid managerId);
        TProject GetProjectById(Guid id);
       public void AddProject(TProject project);
        public void UpdateProject(TProject project);
        public void AddMember(Guid projectId, Guid employeeId);
        public void RemoveMember(Guid projectId, Guid employeeId);
    }
}
