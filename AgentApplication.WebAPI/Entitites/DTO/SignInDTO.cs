using System.ComponentModel.DataAnnotations;

namespace AgentApplication.WebAPI.Entitites.DTO
{
    public class SignInDTO
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
