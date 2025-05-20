using CryptoWallet.BusinessLogic.Interfaces;

namespace CryptoWallet.BusinessLogic
{
    public class BussinesLogicBase
    {
        public ISession GetSessionBL()
        {
            return new SessionBL();
        }
    }
}