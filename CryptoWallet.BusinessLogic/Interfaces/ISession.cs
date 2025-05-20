using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoWallet.BusinessLogic.Interfaces
{
    public interface ISession
    {

        bool IsAuthenticated { get; }
        string UserId { get; }
        void Login(string userId);
        void Logout();
    }
}
