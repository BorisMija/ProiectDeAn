using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoWallet.Domain.User.Auth
{
    public class UserAuthResp
    {
        public bool Status { get; set; }
        public string Error { get; set; }
    }
}