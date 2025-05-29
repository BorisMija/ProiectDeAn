using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoWallet.Domain.Entities.User
{
    public class SellCrypto
    {
          [Key]
          [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
          public int Id { get; set; }
          public string CryptoSymbol { get; set; }
          public decimal Amount { get; set; }
          public decimal Rate { get; set; }
          public int UserId { get; set; }
          public DateTime Date { get; set; }
     }
}
