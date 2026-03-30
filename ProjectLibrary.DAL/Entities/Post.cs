using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectLibrary.DAL.Entities
{
    public class Post
    {
        public Guid PostId { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public DateTime SendDate { get; set; }
        
        public Guid EmployeeId { get; set; }
        public Guid ProjectId { get; set; }
    }
}
