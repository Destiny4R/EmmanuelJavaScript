using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EmmanuelJavaScriptWeb.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Column(TypeName = "varchar()")]
        [MaxLength(100)]
        public string? Name { get; set; }
    }
}
