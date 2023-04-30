using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AspNetNetwork.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        T GetWithFilter(Expression<Func<T, bool>> filter);
        IEnumerable<T> GetAll();
        void Add(T entity);
    }
}
