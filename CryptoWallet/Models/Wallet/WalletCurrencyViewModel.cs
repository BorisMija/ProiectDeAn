using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CryptoWallet.Models.Wallet
{
	public class WalletCurrencyViewModel
	{
          public string Symbol { get; set; }
          public decimal Amount { get; set; }
          public decimal ValueInUsd { get; set; }
     }
}