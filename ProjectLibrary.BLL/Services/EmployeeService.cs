using ProjectLibrary.BLL.Mappers;
using ProjectLibrary.Common.Repositories;
using ProjectLibrary.DAL.Entities;
using ProjectLibrary.BLL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ProjectLibrary.BLL.Services
{
    public class EmployeeService
    {
        private readonly IEmployeeRepository<DAL.Entities.Employee> _employeeRepository;

        public EmployeeService(IEmployeeRepository<DAL.Entities.Employee> employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public IEnumerable<BLL.Entities.Employee> GetAvailableEmployees()
        {
            return _employeeRepository.GetAvailableEmployees().Select(e => e.ToEmployee());
        }
        public BLL.Entities.Employee? GetById(Guid id)
        {
            var dalEmployee = _employeeRepository.GetEmployeeById(id);
            return dalEmployee?.ToEmployee();
        }
        public IEnumerable<BLL.Entities.Employee> GetProjectMembers(Guid projectId)
            {
            return _employeeRepository.GetProjectMember(projectId).Select(e => e.ToEmployee());
        }
    }
}
