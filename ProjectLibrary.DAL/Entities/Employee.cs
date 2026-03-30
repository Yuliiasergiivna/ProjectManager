using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectLibrary.DAL.Entities
{
    public class Employee
    {
        public Guid EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Hiredate  { get; set; }

        public string? Email { get; set; }
        public bool IsProjectManager { get; set; }
    }
}
