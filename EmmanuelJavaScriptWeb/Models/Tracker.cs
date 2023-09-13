using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmmanuelJavaScriptWeb.Models
{
    public class Tracker
    {
        public int Id { get; set; }
        public string AppId { get; set; }
        [ForeignKey(nameof(AppId))]
        public ApplicationUser ApplicationUser { get; set; }
        [StringLength(500)]
        public string WebUrl { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
