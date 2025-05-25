using CryptoWallet.Models;
using System.Collections.Generic;

namespace CryptoWallet.ViewModels
{
    public class WalletViewModel
    {
        public List<WalletCurrency> WalletCurrencies { get; set; }
        public List<Transaction> Transactions { get; set; }
    }
}