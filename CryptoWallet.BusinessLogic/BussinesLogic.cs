using CryptoWallet.BusinessLogic.BLStruct;
using CryptoWallet.BusinessLogic.Interfaces;



namespace CryptoWallet.BusinessLogic
{
    public class BusinessLogic
    {
        private static SessionBL _sessionBL;
        public class BusinesLogic
        {
            public ISession GetSessionBL()
            {
                return new SessionBL();
            }

            public IRegister GetRegisterBL()
            {
                return new RegisterBL();
            }
        }

    }
}
