using CryptoWallet.BusinessLogic.BLStruct;
using CryptoWallet.BusinessLogic.Interfaces;



namespace CryptoWallet.BusinessLogic
{
    public class BussinesLogic
    {
        private static SessionBL _sessionBL;
        public ISession GetSessionBL()
        {
            return new SessionBL();
        }
    }
}
