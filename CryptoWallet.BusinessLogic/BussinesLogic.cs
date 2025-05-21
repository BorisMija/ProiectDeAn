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
