﻿using System;
using System.ComponentModel.DataAnnotations;

namespace CryptoWallet.Models
{
	public class UserDataRegister
	{
        [Required]
        [Display(Name = "Username")]
        [StringLength(30, MinimumLength = 5)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}