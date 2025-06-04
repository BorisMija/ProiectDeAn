using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CryptoWallet.Domain.Entities.User
{
     public class WalletCurrency
     {
          [Key]
          [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
          public int Id { get; set; }

          [Required]
          public string UserName { get; set; }

          [Required]
          public string Symbol { get; set; }

          [Required]
          public decimal Amount { get; set; }

          public string Name { get; set; }
     }
}