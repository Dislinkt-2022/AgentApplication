using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgentApplication.WebAPI.Entitites.Model
{
    [Table("SalaryReviews")]
    public class SalaryReview
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public float Amount { get; set; }

        [Required]
        [StringLength(25)]
        public string Role { get; set; }

        public Company Company { get; set; }
    }
}
