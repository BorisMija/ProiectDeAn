using System;



namespace CryptoWallet.Domain.Entities.User
{
    public class UDataRegister
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public DateTime RegisterDataTime { get; set; }
        public Exception StatusMsg { get; set; }
    }
}
