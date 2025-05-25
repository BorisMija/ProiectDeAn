
using CryptoWallet.Domain.Entities.Session;
using CryptoWallet.Models;
using System.Data.Entity;


namespace CryptoWallet.BusinessLogic.DBModel
{
    public class SessionContext : DbContext
    {
        public SessionContext() :
            base("name=CryptoWallet")
        {
        }
        public virtual DbSet<SessionDbTable> Sessions { get; set; }
        public DbSet<WalletCurrency> WalletCurrencies { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

    }
}
