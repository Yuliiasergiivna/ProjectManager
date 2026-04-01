using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjectLibrary.ASPMVC.Models.Projects
{
    public class ProjectViewModel
    {
        [ScaffoldColumn(false)]
        public Guid ProjectId { get; set; }
        [DisplayName("Nom de projet")]
        public string Name { get; set; }
        [DisplayName("Description : ")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DisplayName("Date de création: ")]
        public DateTime CreationDate { get; set; }
        [DisplayName("Nom de manager: ")]
        public string ManagerName { get; set; }
    }
}
