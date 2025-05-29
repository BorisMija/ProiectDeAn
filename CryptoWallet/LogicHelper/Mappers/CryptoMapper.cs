using CryptoWallet.Domain.Entities.User;
using CryptoWallet.Models.Crypto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CryptoWallet.LogicHelper.Mappers
{
	public static class CryptoMapper
	{
          public static SellCrypto ToEntities(SellCryptoModel product) => new SellCrypto
          {
               CryptoSymbol = product.CryptoSymbol,
               Amount = product.Amount,
               Rate = product.Rate,
               UserId = product.UserId
          };
     }
}