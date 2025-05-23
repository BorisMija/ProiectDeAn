using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CryptoWallet.Models
{
    public class WalletCurrency
    {
     
        public string Name { get; set; }

        
        
        public string Symbol { get; set; }
        public string CurrencyCode { get; set; } 
        public decimal Amount { get; set; }
    }
}