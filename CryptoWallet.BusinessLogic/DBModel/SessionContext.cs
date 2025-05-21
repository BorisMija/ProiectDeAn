
using CryptoWallet.Domain.Entities.Session;
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
    }
}
