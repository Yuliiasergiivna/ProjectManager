using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectLibrary.Common.Repositories
{
    public interface IEmployeeRepository<TEmployee>
    {
            IEnumerable<TEmployee> GetAvailableEmployees();
            TEmployee GetEmployeeById(Guid id);
            IEnumerable<TEmployee> GetProjectMember(Guid projectId);
    }
}
