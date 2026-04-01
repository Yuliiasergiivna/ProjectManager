using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjectLibrary.ASPMVC.Models
{
    public class PostViewModel
    {
        [ScaffoldColumn(false)]
        public Guid PostId { get; set; }
        [DisplayName("Contenu :")]
        public string Content { get; set; }
        [DisplayName("Date d'envoi: ")]
        public DateTime SendDate { get; set; }
        [DisplayName("Auteur: ")]
        public string AuthorName { get; set; }
        [ScaffoldColumn(false)]
        public Guid EmployeeId { get; set; }
        [ScaffoldColumn(false)]
        public Guid ProjectId { get; set; }
    }
}
