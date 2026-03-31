using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectLibrary.BLL.Entities
{
    public class User 
    {
        public Guid UserId { get; private set; }
        public string Email { get; private set; }
        public byte[] Password { get; private set; }
        public Guid Salt { get; private set; }
        public Guid EmployeeId { get; private set; }

        public bool IsProjectManager { get; set; }
        public User(Guid userId, string email, byte[] password,Guid salt, Guid employeeId)
        {
            UserId = userId;
            Email = email;
            Password = password;
            Salt = salt;
            EmployeeId = employeeId;
        }
    }
}
