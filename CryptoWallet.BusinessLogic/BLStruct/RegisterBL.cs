using CryptoWallet.BusinessLogic.Interfaces;
using CryptoWallet.Domain.Entities.User;
using eUseControl.BusinessLogic.Core;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoWallet.BusinessLogic.BLStruct
{

        public class RegisterBL : UserApi, IRegister
        {
    

        public string SignUpLogic(UDataRegister data)
            {
                return RegisterUser(data);
            }
        }
 }

