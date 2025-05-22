using System.ComponentModel.DataAnnotations;

namespace CryptoWallet.Models.Login
{
    public class UserLogin
    {
        [Required]
        [Display(Name = "Username or Email")]
        public string NameOrEmail { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}