using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjectLibrary.ASPMVC.Models.Projects
{
    public class ProjectDetailsViewModel
    {
        [ScaffoldColumn(false)]
        public Guid ProjectId { get; set; }
        [DisplayName("Nom de projet: ")]
        public string Name { get; set; }
        [DisplayName("Description : ")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [DisplayName ("Date de création")]
        public DateTime CreationDate { get; set; }
        [DisplayName("Equipe du projet: ")]
        public List<EmployeeViewModel> Membres { get; set; } = new();
        [DisplayName("Flux des messages ")]
        public List<PostViewModel> Posts { get; set; } = new();
        [DisplayName("Manager de projet: ")]
        public bool isProjectManager { get; set; }
    }
}
