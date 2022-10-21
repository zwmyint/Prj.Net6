using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Prj.Net6.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Prj.Net6.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly PrjNet6DbContext _context;
        protected DbSet<T> dbSet;
        protected readonly ILogger _logger;

        public GenericRepository(PrjNet6DbContext context, ILogger logger)
        {
            _context = context;
            _logger = logger;
            dbSet = _context.Set<T>();
        }
        public async Task<bool> Add(T entity)
        {
            try
            {
                await dbSet.AddAsync(entity);
                //await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public async Task<bool> AddRange(IEnumerable<T> entities)
        {
            try
            {
                await dbSet.AddRangeAsync(entities);
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            
        }

        public async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> expression)
        {
            return await dbSet.Where(expression).ToListAsync();
        }

        //public async Task<IEnumerable<T>> Find2(Expression<Func<T, bool>> predicate)
        //{
        //    return await dbSet.Where(predicate).ToListAsync();
        //}

        public async Task<IEnumerable<T>> GetAll()
        {
            return await dbSet.ToListAsync();
        }

        public async Task<T> GetById(Guid id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task<bool> Remove(Guid id)
        {
            var t = await dbSet.FindAsync(id);

            if (t != null)
            {
                dbSet.Remove(t);
                //await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool RemoveRange(IEnumerable<T> entities)
        {
            try
            {
                dbSet.RemoveRange(entities);
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
            
        }

        public async Task<bool> Update(T entity)
        {
            throw new NotImplementedException();
        }


    }

}
