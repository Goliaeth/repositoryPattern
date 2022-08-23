namespace CustomerManagement.Interfaces
{
    public interface IRepository<TEntity>
    {
        TEntity Create(TEntity entity);
        TEntity Read(string entityCode);
        TEntity Update(TEntity entity);
        void Delete(string entityCode);
    }
}
