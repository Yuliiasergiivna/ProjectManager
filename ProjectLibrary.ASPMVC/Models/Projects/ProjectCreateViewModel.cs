using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjectLibrary.ASPMVC.Models.Projects
{
    public class ProjectCreateViewModel
    {
        [ScaffoldColumn(false)]
        public Guid ProjectId { get; set; }
        [ScaffoldColumn(false)]
        public Guid ProjectManagerId { get; set; }
        [DisplayName("Nom de projet: ")]
        public string Name { get; set; }
        [DisplayName("Description: ")]
        public string Description { get; set; }
        [DisplayName("Date de création: ")]
        public DateTime CreationDate { get; set; }
    }
}
