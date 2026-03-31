using ProjectLibrary.BLL.Mappers;
using ProjectLibrary.Common.Repositories;
using ProjectLibrary.DAL.Entities;
using BLL = ProjectLibrary.BLL.Entities;
using DAL = ProjectLibrary.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using ProjectLibrary.BLL.Entities;

namespace ProjectLibrary.BLL.Services
{
    public class AuthService
    {
        private readonly IUserRepository<DAL.Entities.User> _userRepository;
        private readonly IEmployeeRepository<DAL.Entities.Employee> _employeeRepository;

        public AuthService(
            IUserRepository<DAL.Entities.User> userRepository,
            IEmployeeRepository<DAL.Entities.Employee> employeeRepository)
        {
            _userRepository = userRepository;
            _employeeRepository = employeeRepository;
        }
        public Guid Add(BLL.Entities.User user)
        { 
            return _userRepository.Add(user.ToDalUser());
        }

        public BLL.Entities.User CheckPassword(string email, string password)
        {
            Guid? employeeId = _userRepository.CheckPassword(email, password);
                if (employeeId == null)
                {
                    return null;
                }
                var dalEmployee = _employeeRepository.GetEmployeeById(employeeId.Value);
                var user = new BLL.Entities.User
                (
                    Guid.Empty,
                    email,
                    null,
                    Guid.Empty,
                    employeeId.Value
                    );
            user.IsProjectManager = dalEmployee.IsProjectManager;
            return user;
        }
        public bool EmailExists(string email)
        {
            return _userRepository.EmailExists(email);
        }
        public BLL.Entities.User GetFromEmployee(Guid employeeId)
        {
            var dalUser = _userRepository.GetFromEmployee(employeeId);
            if (dalUser == null)
            {
                return null;
            }
            return dalUser.ToUser();
        }
    }
}
