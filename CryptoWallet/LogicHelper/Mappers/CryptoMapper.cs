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
          public static SellCrypto ToEntities(SellCryptoModel offer) => new SellCrypto
          {
               CryptoSymbol = offer.CryptoSymbol,
               Amount = offer.Amount,
               Rate = offer.Rate,
               UserName = offer.UserName,
           
          };
          public static SellCryptoModel ToModel(SellCrypto entity) => new SellCryptoModel
          {
               CryptoSymbol = entity.CryptoSymbol,
               Amount = entity.Amount,
               Rate = entity.Rate,
               UserName = entity.UserName,
               isAvailable = entity.isAvailable
          };

     }
}