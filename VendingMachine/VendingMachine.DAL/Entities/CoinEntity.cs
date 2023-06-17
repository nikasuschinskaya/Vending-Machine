using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VendingMachine.DAL.Entities.Base;

namespace VendingMachine.DAL.Entities
{
    [Table("Coins")]
    public class CoinEntity : CountedEntity
    {
        [Required]
        public int Denomination { get; set; }
    }
}