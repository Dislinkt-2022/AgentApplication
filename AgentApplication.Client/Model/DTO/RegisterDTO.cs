using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace AgentApplication.Client.Model.DTO
{
    public class RegisterDTO
    {
        [Required]
        [MaxLength(25)]
        public string? FirstName { get; set; }

        [Required]
        [MaxLength(25)]
        public string? LastName { get; set; }

        [Required]
        public string? UserName { get; set; }

        [Required]
        [MinLength(6)]
        public string? Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Passwords doesn't match")]
        public string? ConfirmPassword { get; set; }

        [Required]
        [CustomValidation(typeof(RegisterDTO), nameof(ValidateEmail))]
        public string? Email { get; set; }

        public static ValidationResult? ValidateEmail(string email, ValidationContext vc)
        {
            var regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            var match = regex.Match(email);

            return match.Success ? ValidationResult.Success : new ValidationResult("Invalid email");
        }
    }
}
