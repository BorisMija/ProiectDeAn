using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoWallet.Domain.User.Auth
{
    public class UserAuthAction
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime LoginTime { get; set; }
    }
}