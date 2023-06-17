using VendingMachine.DAL.Entities.Base;

namespace VendingMachine.DAL.Entities
{
    public class CoinEntity : CountedEntity
    {
        public int Denomination { get; set; }

        public CoinEntity(int id, int count, int denomination) : base(id, count) => Denomination = denomination;

    }
}
