using CustomerManagement.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Interfaces
{
    public interface IDepRepository<TEntity> : IRepository<TEntity>
    {
        List<TEntity> GetAllById(string id);
    }
}
