namespace VendingMachine.DAL.Entities.Base
{
    public class CountedEntity : BaseEntity
    {
        public int Count { get; set; }

        public CountedEntity(int id, int count) : base(id) => Count = count;
    }
}
