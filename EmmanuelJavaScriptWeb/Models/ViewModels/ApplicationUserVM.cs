using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EmmanuelJavaScriptWeb.Models.ViewModels
{
    public class ApplicationUserVM
    {
        [Required]
        [Display(Name ="Full Name")]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Compare(nameof(Password))]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        
    }
}
