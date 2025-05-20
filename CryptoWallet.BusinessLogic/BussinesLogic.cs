using CryptoWallet.BusinessLogic.Interfaces;
using CryptoWallet.BusinessLogic;
using CryptoWallet.BusinessLogic.Interfaces;

namespace CryptoWallet.BusinessLogic
{
    public class BussinesLogic
    {
        public ISession GetSessionBL()
        {
            return new SessionBL();
        }
    }
}
