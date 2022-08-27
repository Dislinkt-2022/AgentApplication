using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgentApplication.WebAPI.Entitites.Model
{
    [Table("Companies")]
    public class Company
    {
        public int Id { get; set; }

        [Required]
        [StringLength(70)]
        public string CompnyName { get; set; }

        [Required]
        [StringLength(50)]
        public string HeadOffice { get; set; }

        [Required]
        [StringLength(30)]
        public string WebUrl { get; set; }

        [Required]
        [StringLength(25)]
        public string Email { get; set; }

        [Required]
        [StringLength(25)]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(50)]
        public string Industry { get; set; }

        [Required]
        [StringLength(500)]
        public string About { get; set; }

        [Required]
        public string OwnerId { get; set; }
        public bool IsApproved { get; set; }

        public User Owner { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<SalaryReview> SalaryReviews { get; set; }
        public ICollection<InterviewProccessReview> InterviewProccessReviews { get; set; }
        public ICollection<JobPost> JobPosts { get; set; }
    }
}
