using CryptoWallet.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoWallet.Domain.Entities.User.UserActionResponse
{
    public class UserResp
    {
        public int UserId { get; set; }
        public bool Status { get; set; }
        public LogInResult Result { get; set; }
        public URole Role { get; set; }
        public string Name { get; set; }
    }
}
