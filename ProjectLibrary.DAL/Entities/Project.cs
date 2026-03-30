using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectLibrary.DAL.Entities
{
    public class Project
    {
        public Guid ProjectId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public Guid ProjectManagerId { get; set; }   
    }
}
