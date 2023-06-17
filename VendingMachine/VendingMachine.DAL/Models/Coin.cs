using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VendingMachine.DAL.Enums;
using VendingMachine.DAL.Models.Entities;

namespace VendingMachine.DAL.Models.Models
{
    [Table("Coins")]
    public class Coin : CountedEntity
    {
        [Required]
        public int Denomination { get; set; }


        [NotMapped]
        public State CoinState { get; set; }
    }
}