using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CryptoWallet.Models.Crypto
{
     public class SellCryptoModel
     {
          [Required(ErrorMessage = "Crypto symbol is required.")]
          public string CryptoSymbol { get; set; }

          [Required(ErrorMessage = "Amount is required.")]
          [Range(0.00000001, double.MaxValue, ErrorMessage = "Amount must be greater than zero.")]
          public decimal Amount { get; set; }

          [Required(ErrorMessage = "Rate is required.")]
          [Range(0.00000001, double.MaxValue, ErrorMessage = "Rate must be greater than zero.")]
          public decimal Rate { get; set; }

          public int UserId { get; set; }
     }
}