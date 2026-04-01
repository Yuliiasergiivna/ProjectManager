using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjectLibrary.ASPMVC.Models
{
    public class EmployeeViewModel
    {
        [ScaffoldColumn(false)]
        public Guid EmployeeId { get; set; }
        [DisplayName("Prénom: ")]
        public string FirstName { get; set; }
        [DisplayName("Nom: ")]
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        [DisplayName("Email: ")]
        public string Email { get; set; }
        [DisplayName("Manager de projet: ")]
        public bool IsProjectManager { get; set; }

    }
}
