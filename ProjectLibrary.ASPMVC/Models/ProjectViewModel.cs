using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjectLibrary.ASPMVC.Models
{
    public class ProjectViewModel
    {
        [ScaffoldColumn(false)]
        public Guid ProjectId { get; set; }
        [DisplayName("Nom de project")]
        public string Name { get; set; }
        [DisplayName("Description")]
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public string ManagerName { get; set; }
    }
}
