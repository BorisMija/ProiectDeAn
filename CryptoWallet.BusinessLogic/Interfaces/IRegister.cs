using CryptoWallet.Domain.Entities.User;

namespace CryptoWallet.BusinessLogic.Interfaces
{

    public interface IRegister
    {
        string SignUpLogic(UDataRegister data);
    }

}
