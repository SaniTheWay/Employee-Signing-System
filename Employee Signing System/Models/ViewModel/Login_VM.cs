using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Employee_Signing_System.Models.ViewModel
{
    public class Login_VM
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }


        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name ="Remember Me")]
        public bool RememberMe { get; set; }
    }
}
