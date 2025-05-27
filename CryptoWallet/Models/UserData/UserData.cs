using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CryptoWallet.Models.UserData
{
	public class UserData
	{
          public string Username { get; set; }
          public string Email { get; set; }
          public int Level { get; set; }
          public bool IsBlocked { get; set; }
          public decimal AccountBalance { get; set; }
          public DateTime LastLogin { get; set; }

          // Additional properties can be added as needed
          // e.g., ProfilePictureUrl, LastLoginDate, etc.
     }
}