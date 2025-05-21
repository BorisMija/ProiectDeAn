using CryptoWallet.Domain.Entities.User;

namespace CryptoWallet.BusinessLogic.Interfaces
{
    public interface ISession
    {
        ULoginResp UserLogin(ULoginData data);
    }
}
