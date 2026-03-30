using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectLibrary.BLL.Entities
{
    public class Employee
    {
        public Guid EmployeeId { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateTime Hiredate { get; private set; }
        private bool _isProjectManager;
        public bool IsProjectManager { get
            {return _isProjectManager; }
        }
        public string? Email { get; set; }

        public Employee(Guid employeeId, string firstName, string lastName, DateTime hiredate, bool isProjectManager)
        {
            EmployeeId = employeeId;
            FirstName = firstName;
            LastName = lastName;
            Hiredate = hiredate;
            _isProjectManager = isProjectManager;
        }
    }

}
