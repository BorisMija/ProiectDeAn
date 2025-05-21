using System;

namespace CryptoWallet.Domain.Entities.User
{
   public class ULoginData
    {


        public string Id { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Credential { get; set; }
        public string Password { get; set; }
        public string LoginIp { get; set; }
        public DateTime LastLogin { get; set; }

        public string Email { get; set; } = string.Empty;
        public bool IsActive { get; set; }

    }
    
}


