using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoWallet.Domain.Enums
{
    public enum URole
    {
        Guest = 0,
        User = 10,
        Moderator = 101,
        Admin = 237,
        Superadmin = 1200
    }
}