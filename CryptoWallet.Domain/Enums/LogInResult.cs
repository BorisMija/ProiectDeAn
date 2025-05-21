using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoWallet.Domain.Enums
{
    public enum LogInResult
    {
        Success,
        EmailNotFound,
        UserNotFound,
        WrongPassword,
        AccountLocked,
        AccountInactive,
        InvalidToken,
        TokenExpired,
        UnknownError
    }
}
