using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.DataAccess.Modules.Shared;

namespace Demo.DataAccess.Repositories.Interfaces
{
    public interface IGenericReprository<TEntity> where TEntity : BaseEntity
    {
        int Add(TEntity entity);
        IEnumerable<TEntity> GetAll(bool withTracking = false);
        TEntity GetById(int id);
        int Remove(TEntity entity);
        int Update(TEntity entity);
    }
}
