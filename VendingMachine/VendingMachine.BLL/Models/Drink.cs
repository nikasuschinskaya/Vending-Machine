using VendingMachine.DAL.Enums;

namespace VendingMachine.BLL.Models
{
    public class Drink
    {
        public int DrinkId { get; }

        public string Name { get; set; }

        public decimal Cost { get; set; }

        public State DrinkState { get; set; }

        public Drink(int drinkId, string name, decimal cost, State drinkState = State.None)
        {
            DrinkId = drinkId;
            Name = name;
            Cost = cost;
            DrinkState = drinkState;
        }
    }
}
