using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace AgentApplication.WebAPI.Entitites.Model
{
    [Table("Users")]
    public class User : IdentityUser
    {
        [Required]
        [StringLength(25)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(25)]
        public string LastName { get; set; }
        public bool IsAdmin { get; set; }
       
        public ICollection<Company> OwnedCompanies { get; set; }
    }
}
