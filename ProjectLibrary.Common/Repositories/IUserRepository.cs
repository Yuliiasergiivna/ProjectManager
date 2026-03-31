
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectLibrary.Common.Repositories
{
    public interface IUserRepository<TUser>
    {
        public Guid Add (TUser user);
        public Guid? CheckPassword(string email, string password);
        public bool EmailExists(string email);
        public TUser GetFromEmployee (Guid employeeId);

    }
}
