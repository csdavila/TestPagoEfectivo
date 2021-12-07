using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PagoEfectivo.PromoCode.Infrastructure.Data;
using PagoEfectivo.PromoCode.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PagoEfectivo.PromoCode.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected ApplicationDbContext context;
        internal DbSet<T> dbSet;
        public readonly ILogger _logger;

        public GenericRepository(
            ApplicationDbContext context,
            ILogger logger)
        {
            this.context = context;
            this.dbSet = context.Set<T>();
            _logger = logger;
        }
        public virtual async Task<IEnumerable<T>> All()
        {
            return await dbSet.ToListAsync();
        }
        public virtual async Task<T> GetById(int id)
        {
            return await dbSet.FindAsync(id);
        }
        public virtual async Task<bool> Add(T entity)
        {
            await dbSet.AddAsync(entity);
            return true;
        }
        public virtual async Task<bool> Delete(int id)
        {
            var exist = await dbSet.FindAsync(id);

            if (exist == null) return false;

            dbSet.Remove(exist);

            return true;
        }
        public async Task Update(T entity)
        {
            dbSet.Update(entity);
        }
        public async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate)
        {
            return await dbSet.Where(predicate).ToListAsync();
        }
    }
}
