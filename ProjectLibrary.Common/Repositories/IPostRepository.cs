
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectLibrary.Common.Repositories
{
    public interface IPostRepository<TPost>
    {
        IEnumerable<TPost> GetPostsByProjectManager(Guid projectId);
        IEnumerable<TPost> GetPostsByEmployeeId(Guid employeeId);
        public void AddPost(TPost post);
        public void UpdatePost(TPost post);
       
    }
}
