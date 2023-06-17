using VendingMachine.DAL.Models.Entities.Base;

namespace VendingMachine.DAL.Models.Entities
{
    public class CountedEntity : BaseEntity
    {
        public int Count { get; set; }
    }
}
