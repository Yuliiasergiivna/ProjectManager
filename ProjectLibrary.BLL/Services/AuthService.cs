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

        public Guid? CheckPassword(string email, string password)
        {
           return _userRepository.CheckPassword(email, password);

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
