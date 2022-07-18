using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Tawasol.BL.Interface
{
    public interface IBaseRep<T> where T : class
    {
        Task<T> FindAsync(Expression<Func<T, bool>> expression, string[] includes = null);

        T Update(T entity); 
        T Delete(T entity);
        Task<T> AddAsync(T entity); 
    }
}
