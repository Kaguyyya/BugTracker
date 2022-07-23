using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BugTrackerWeb.Models
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Das Feld ist pflicht")]
        [DisplayName("Name")]
        public string ProjectName { get; set; }
        [Required(ErrorMessage = "Das Feld ist pflicht")]
        [DisplayName("Beschreibung")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Das Feld ist pflicht")]
        [DisplayName("Status")]
        public string Status { get; set; } = "Aktiv";

        [Required(ErrorMessage = "Das Feld ist pflicht")]
        [DisplayName("Zugewiesen an")]
        public string AssignedTo { get; set; }
        [Required(ErrorMessage = "Das Feld ist pflicht")]
        [DisplayName("Tester")]
        public string FoundBy { get; set; }
        [Required(ErrorMessage = "Das Feld ist pflicht")]
        [DisplayName("Priorität")]
        public string Severity { get; set; }
        [DisplayName("Tester Kommentar")]
        [Required(ErrorMessage = "Das Feld ist pflicht")]
        public string TesterComment { get; set; } = String.Empty;

        public string DevoloperComment { get; set; } =String.Empty;
    }
}
