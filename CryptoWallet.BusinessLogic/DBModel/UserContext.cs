using System.Data.Entity;
using CryptoWallet.BusinessLogic.DBModel;
using CryptoWallet.Domain.Entities.User;



namespace CryptoWallet.BusinessLogic.DBModel
{
   public  class UserContext : DbContext
    {
        public UserContext() :
            base("name=CryptoWallet")
        {
        }

        public virtual DbSet<UDbTable> Users { get; set; }
        public DbSet<WalletCurrency> WalletCurrencies { get; set; }
        public DbSet<SellCrypto> SellCryptos { get; set; }


     }
}
