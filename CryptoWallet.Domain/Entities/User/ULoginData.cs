using System;

namespace CryptoWallet.Domain.Entities.User
{
   public class ULoginData
    {


        public string UserId { get; set; } = string.Empty;
        public string NameOrEmail { get; set; } = string.Empty;
        public string Credential { get; set; }
        public string Password { get; set; }
        public string LoginIp { get; set; }
        public DateTime LoginDataTime { get; set; }

        public bool IsActive { get; set; }
        public DateTime LoginDateTime { get; set; }
    }
    
}


