namespace VendingMachine.DAL.Repositories.Base
{
    public interface IRepository<T>
    {
        bool Create(T entity);
        bool Update(T entity);
        bool Delete(int id);
        T GetById(int id);
        IEnumerable<T> GetAll();
    }
}
