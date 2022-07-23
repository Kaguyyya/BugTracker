using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace BugTrackerWeb.Models
{
    public class Account
    {
        
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Pflichtfeld")]
        [DisplayName("Anzeigename")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Pflichtfeld")]
        [DisplayName("E-Mail")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Pflichtfeld")]
        [DataType(DataType.Password)]
        [DisplayName("Passwort")]
        public string Password { get; set; }
        
        [Compare("Password",ErrorMessage = "Passwörter stimmen nicht überein")]
        
        [DataType(DataType.Password)]
        [DisplayName("Passwort Bestätigen")]
        [Required(ErrorMessage ="Pflichtfeld")]
        
        public string ConfirmPassword { get; set; }
    }
}
