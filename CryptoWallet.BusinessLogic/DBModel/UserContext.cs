using System.Data.Entity;
using CryptoWallet.BusinessLogic.DBModel;
using CryptoWallet.Domain.Entities.User;

namespace eUseControl.BusinessLogic.DBModel
{
    class UserContext : DbContext
    {
        public UserContext() :
            base("name=CryptoWallet") // connectionstring name define in your web.config
        {
        }

        public virtual DbSet<UDbTable> Users { get; set; }
    }
}
