using CryptoWallet.BusinessLogic.Core;
using CryptoWallet.BusinessLogic.Interfaces;
using System;


namespace CryptoWallet.BusinessLogic
{
    public class BussinesLogic
    {
        private static SessionBL _sessionBL;

        public static ISession GetSessionBL()
        {
            _sessionBL = new SessionBL();
            return _sessionBL;
        }

        private readonly ISession _session;
        private readonly AdminApi _adminApi;
        private readonly UserApi _userApi;

        public BusinessLogic(ISession session)
        {
            _session = session;
            _adminApi = new AdminApi();
            _userApi = (UserApi)session;
        }

        public AdminApi Admin => _session.IsAuthenticated ? _adminApi : throw new UnauthorizedAccessException("Admin access requires authentication");
        public UserApi User => _userApi;
    }
}
