using ProjectLibrary.BLL.Mappers;
using ProjectLibrary.Common.Repositories;
using ProjectLibrary.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectLibrary.BLL.Services
{
    public class PostService
    {
        private readonly IPostRepository<DAL.Entities.Post> _postRepository;

        public PostService(IPostRepository<DAL.Entities.Post> postRepository)
        {
            _postRepository = postRepository;
        }
        public void AddPost(BLL.Entities.Post post)
        {
            _postRepository.AddPost(post.ToDalPost());
        }
        public void UpdatePost(BLL.Entities.Post post)
        {
            _postRepository.UpdatePost(post.ToDalPost());
        }
         public IEnumerable<BLL.Entities.Post> GetPostsByProjectManager(Guid projectId)
        {
            return _postRepository.GetPostsByProjectManager(projectId).Select(p => p.ToPost());
        }
        public IEnumerable<BLL.Entities.Post> GetPostsByEmployeeId(Guid employeeId)
        {
            return _postRepository.GetPostsByEmployeeId(employeeId).Select(p => p.ToPost());
        }
    }
}
