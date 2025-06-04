using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CryptoWallet.Models.Wallet
{
	public class WalletAddModel
	{
          [Required]
          public string Symbol { get; set; }

          [Required]
          [Range(0.00000001, double.MaxValue)]
          public decimal Amount { get; set; }
     }
}