using System.ComponentModel.DataAnnotations;

namespace EF_core.Model
{
    public class LoginModel
    {
        [Required (ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Email address is not valid")]
        public string Email { get; set; }

        [Required (ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
