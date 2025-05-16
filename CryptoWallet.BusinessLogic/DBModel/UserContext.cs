using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoWallet.BusinessLogic.DBModel
{
    class UserContext : DbContext
    {
        public UserContext() :
            base("name=CryptoWallet")
        {

        }

    }public virtual  DbSet<UDbTable> Users { get; set; }
}
