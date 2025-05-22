using CryptoWallet.BusinessLogic.Interfaces;
using CryptoWallet.Domain.Entities.User;
using CryptoWallet.Domain.Entities.User.UserActionResponse;
using eUseControl.BusinessLogic.Core;


namespace CryptoWallet.BusinessLogic.BLStruct
{
 
    public class SessionBL : UserApi, ISession
    {
        //public UserCookieResponse GenerateCookieByUser(int id)
        //{
        //    return GenerateCookieByUserAction(id);
        //}

        //public UserResp GetUserByCookie(string sessionKey)
        //{
        //    return GetUserByCookieAction(sessionKey);
        //}

        public UserResp LogInLogic(ULoginData data)
        {
            return LogInUser(data);
        }
        public UDataRegister UserReg(UDataRegister data)
        {
            return RegisterUser(data);
        }
        public UDataRegister UserLogin(ULoginData data)
        {
            throw new System.NotImplementedException();
        }
    }
}

