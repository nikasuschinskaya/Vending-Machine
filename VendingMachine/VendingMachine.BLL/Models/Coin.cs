using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VendingMachine.BLL.Enums;

namespace VendingMachine.BLL.Models
{
    [Table("Coins")]
    public class Coin
    {
        [Key]
        [Required]
        public int CoinId { get; }

        [Required]
        public int Denomination { get; set; }


        public int Count { get; set; }


        [NotMapped]
        public State CoinState { get; set; }
    }
}