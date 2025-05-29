using System.Data.Entity;
using CryptoWallet.BusinessLogic.DBModel;
using CryptoWallet.Domain.Entities.User;
using CryptoWallet.Domain.Entities.User;


namespace CryptoWallet.BusinessLogic.DBModel
{
   public  class UserContext : DbContext
    {
        public UserContext() :
            base("name=CryptoWallet") // connectionstring name define in your web.config
        {
        }

        public virtual DbSet<UDbTable> Users { get; set; }
        public DbSet<WalletCurrency> WalletCurrencies { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<SellCrypto> SellCryptos { get; set; }


     }
}
