using VendingMachine.DAL.Enums;

namespace VendingMachine.BLL.Models
{
    public class Drink
    {
        public int DrinkId { get; set; }

        public string Name { get; set; }

        public int Count { get; set; }

        public decimal Cost { get; set; }

        public State DrinkState { get; set; }

        public Drink(int drinkId, string name,int count, decimal cost, State drinkState = State.None)
        {
            DrinkId = drinkId;
            Name = name;
            Count = count;
            Cost = cost;
            DrinkState = drinkState;
        }

        public override bool Equals(object? obj)
        {
            return obj is Drink drink &&
                   DrinkId == drink.DrinkId &&
                   Name == drink.Name &&
                   Count == drink.Count &&
                   Cost == drink.Cost &&
                   DrinkState == drink.DrinkState;
        }
    }
}
