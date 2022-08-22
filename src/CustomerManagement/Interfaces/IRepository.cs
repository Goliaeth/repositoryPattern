using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Interfaces
{
    public interface IRepository<TEntity>
    {
        void Create(TEntity customer);
        TEntity Read(string entityCode);
        void Update(TEntity customer);
        void Delete(string entityCode);
    }
}
