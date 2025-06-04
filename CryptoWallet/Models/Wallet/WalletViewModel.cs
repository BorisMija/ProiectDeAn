using CryptoWallet.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CryptoWallet.Models.Wallet
{
	public class WalletViewModel
	{
          public List<WalletCurrency> Currencies { get; set; }
          public WalletAddModel AddModel { get; set; }

     }
}