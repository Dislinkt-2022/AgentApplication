using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgentApplication.WebAPI.Entitites.Model
{
    [Table("JobPostPrerequisites")]
    public class JobPostPrerequisite
    {
        public int Id { get; set; }
        public int JobPostId { get; set; }

        [Required]
        [StringLength(50)]
        public string Prerequisite { get; set; }

        public JobPost JobPost { get; set; }
    }
}
