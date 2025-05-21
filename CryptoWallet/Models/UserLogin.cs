using System.ComponentModel.DataAnnotations;

namespace CryptoWallet.Models
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