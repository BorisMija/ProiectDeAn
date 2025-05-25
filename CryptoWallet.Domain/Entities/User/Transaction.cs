using System;



namespace CryptoWallet.Models
{
    public class Transaction
    {
        public int Id { get; set; }
     

        public string Type { get; set; }
        public string Currency { get; set; }

       
        public decimal Amount { get; set; }
    
        public decimal ValueInUSD { get; set; }

        public DateTime Date { get; set; }
        public string UserId { get; set; }
    }
}