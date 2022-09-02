using CustomerManagement.BusinessEntities;
using System.Collections.Generic;

namespace CustomerManagement.Interfaces
{
    public interface IRepository<TEntity>
    {
        TEntity Create(TEntity entity);
        TEntity Read(string entityCode);
        TEntity Update(TEntity entity);
        void Delete(string entityCode);
        List<TEntity> GetAll();
        List<TEntity> Read(int offset, int maxRecords);
        int Count();
        List<TEntity> Read(int offset, int maxRecords, string customerIdReq);
    }
}
