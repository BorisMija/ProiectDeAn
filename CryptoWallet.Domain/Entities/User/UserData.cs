using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoWallet.Domain.Entities.User
{
    public class UserData
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public int Level { get; set; }
        public bool IsBlocked { get; set; }
        public decimal AccountBalance { get; set; }
    }
}