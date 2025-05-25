using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CryptoWallet.Models
{
    public class WalletCurrency
    {
        [Key]
        public int Id { get; set; } 

        public string Name { get; set; }

        public string Username { get; set; }

        [Required]
        [StringLength(10)]
        public string Symbol { get; set; }

      
        public string CurrencyCode { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal Amount { get; set; }

        [Required]
        public string UserId { get; set; }

   
    }
}