using CryptoWallet.Domain.Entities.User;
using CryptoWallet.Domain.Entities.User.UserActionResponse;

namespace CryptoWallet.BusinessLogic.Interfaces
{
    public interface ISession
    {
        UDataRegister UserLogin(ULoginData data);
        UDataRegister UserReg(UDataRegister data);
        UserResp LogInLogic(ULoginData data);

        //UserCookieResponse GenerateCookieByUser(int id);

        //UserResp GetUserByCookie(string sessionKey);

    }
}
