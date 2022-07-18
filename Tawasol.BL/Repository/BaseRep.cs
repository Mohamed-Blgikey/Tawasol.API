

using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Tawasol.BL.Interface;
using Tawasol.DAL.Database;

namespace Tawasol.BL.Repository
{
    public class BaseRep<T> : IBaseRep<T> where T : class
    {
        #region fields
        private readonly AppDbContext context;

        #endregion


        #region Ctor
        public BaseRep(AppDbContext context)
        {
            this.context = context;
        }

        
        #endregion

        public async Task<T> FindAsync(Expression<Func<T, bool>> expression, string[] includes = null)
        {
            IQueryable<T> date = context.Set<T>();
            if (includes != null)
                foreach (var include in includes)
                    date = date.Include(include);

            return await date.FirstOrDefaultAsync(expression);
        }


        public async Task<T> AddAsync(T entity)
        {
            var date = await context.Set<T>().AddAsync(entity);
            return date.Entity;
        }

        public T Update(T entity)
        {
            var data = context.Set<T>().Update(entity);
            return data.Entity;
        }

        public T Delete(T entity)
        {
            var data = context.Set<T>().Remove(entity);
            return data.Entity;
        }
    }
}
