using BusinessObject.Models;
using DataAccess.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Implementation
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly StoreDbContext context;
        protected DbSet<T> dbSet;
        public GenericRepository(StoreDbContext context)
        {
            this.context = context;
            dbSet = context.Set<T>();
        }

        public async Task<T> AddAsync(T entity)
        {
            dbSet.Add(entity);
            var result = await context.SaveChangesAsync() > 0;
            if (result)
            {
                return entity;
            }
            return null;
        }

        public async Task<Boolean> Delete(int id)
        {
            T existing = await dbSet.FindAsync(id);
            if (existing != null)
            {
                dbSet.Remove(existing);
                await context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public Task<List<T>> Find(Expression<Func<T, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public async Task<List<T>> GetAllAsync()
        {
            var items = await dbSet.ToListAsync();
            return items;
        }

        public async Task<T> GetById(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task<Boolean> Updater(T entity)
        {
            bool check = false;
            dbSet.Update(entity);
            var isSuccess = await context.SaveChangesAsync() > 0;
            if (isSuccess) check = true;
            return check;
        }
    }
}
