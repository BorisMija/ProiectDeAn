
namespace CryptoWallet.BusinessLogic.Core
{
    public interface IUserApi
    {
         void Register(string username, string password, string email);
         bool Login(string username, string password);
        void UpdateProfile(string userId, string newEmail);
        void ChangePassword(string userId, string oldPassword, string newPassword);

    }
}