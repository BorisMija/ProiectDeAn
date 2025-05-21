using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace CryptoWallet.Domain.Entities.Session
{
   public class SessionDbTable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public string Cookie { get; set; }
        [Required]
        public DateTime ValidTime { get; set; }
    }
}
