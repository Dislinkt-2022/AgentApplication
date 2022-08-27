using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgentApplication.WebAPI.Entitites.Model
{
    [Table("Comments")]
    public class Comment
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }

        [Required]
        [StringLength(500)]
        public string Text { get; set; }
        public int Rating { get; set; }

        [Required]
        [StringLength(25)]
        public string Role { get; set; }
        public bool IsCurrentlyEmployed { get; set; }

        [Required]
        public DateTime SubmittedAtUtc { get; set; }

        public Company Company { get; set; }
    }
}
