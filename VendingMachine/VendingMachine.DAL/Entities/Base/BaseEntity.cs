namespace VendingMachine.DAL.Entities.Base
{
    public abstract class BaseEntity
    {
        public int Id { get; }

        protected BaseEntity(int id) => Id = id;
    }
}
