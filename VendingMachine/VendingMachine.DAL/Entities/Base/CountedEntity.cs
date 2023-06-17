using VendingMachine.DAL.Models.Entities.Base;

namespace VendingMachine.DAL.Entities.Base
{
    public class CountedEntity : BaseEntity
    {
        public int Count { get; set; }
    }
}
