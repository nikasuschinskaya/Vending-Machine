using VendingMachine.BLL.Enums;

namespace VendingMachine.BLL.Models
{
    public class Drink
    {
        public int DrinkId { get; }

        public string Name { get; set; }

        public decimal Cost { get; set; }

        public State DrinkState { get; set; }
    }
}
