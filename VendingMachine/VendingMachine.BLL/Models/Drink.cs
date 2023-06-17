using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VendingMachine.BLL.Enums;

namespace VendingMachine.BLL.Models
{
    [Table("Drinks")]
    public class Drink
    {
        [Key]
        [Required]
        public int DrinkId { get; }

        [MaxLength(25)]
        [Required]
        public string Name { get; set; }


        public int Count { get; set; }


        [Required]
        public decimal Cost { get; set; }


        [NotMapped]
        public State DrinkState { get; set; }
    }
}
