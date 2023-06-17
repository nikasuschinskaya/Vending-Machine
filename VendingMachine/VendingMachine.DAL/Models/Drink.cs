using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VendingMachine.DAL.Enums;
using VendingMachine.DAL.Models.Entities;

namespace VendingMachine.DAL.Models
{
    [Table("Drinks")]
    public class Drink : CountedEntity
    {
        [MaxLength(25)]
        [Required]
        public string Name { get; set; }


        [Required]
        public decimal Cost { get; set; }


        [NotMapped]
        public State DrinkState { get; set; }
    }
}
