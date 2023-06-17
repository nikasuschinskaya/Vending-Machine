using VendingMachine.DAL.Entities.Base;

namespace VendingMachine.DAL.Entities
{
    public class DrinkEntity : CountedEntity
    {
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public DrinkEntity(int id, int count, string name, decimal cost) : base(id, count)
        {
            Name = name;
            Cost = cost;
        }
    }
}
