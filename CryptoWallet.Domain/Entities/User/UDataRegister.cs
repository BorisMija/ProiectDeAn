using System;



namespace CryptoWallet.Domain.Entities.User
{
    public class UDataRegister
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Id { get; set; } = string.Empty;
        public string NameOrEmail { get; set; } = string.Empty;
        public string Credential { get; set; }
        public string Password { get; set; }
        public string LoginIp { get; set; }
        public DateTime LoginDateTime { get; set; }
        public bool Status { get; set; }
        public string StatusMsg { get; set; }
    }
}
