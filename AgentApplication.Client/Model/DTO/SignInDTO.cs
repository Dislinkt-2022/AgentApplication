using System.ComponentModel.DataAnnotations;

namespace AgentApplication.Client.Model.DTO
{
    public class SignInDTO
    {
        [Required]
        public string? UserName { get; set; }

        [Required]
        [MinLength(6)]
        public string? Password { get; set; }
    }
}
