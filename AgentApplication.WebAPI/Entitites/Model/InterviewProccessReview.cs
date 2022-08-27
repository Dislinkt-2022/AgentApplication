using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgentApplication.WebAPI.Entitites.Model
{
    [Table("InterviewProccessReviews")]
    public class InterviewProccessReview
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
        public bool IsAcceptedOffer { get; set; }

        [Required]
        public DateTime SubmittedAtUtc { get; set; }

        public Company Company { get; set; }
    }
}
