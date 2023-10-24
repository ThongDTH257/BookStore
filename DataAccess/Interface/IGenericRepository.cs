using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interface
{
    public interface IGenericRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T> AddAsync(T entity);
        Task<Boolean> Updater(T entity);
        Task<Boolean> Delete(int id);
        Task<T> GetById(int id);
        Task<List<T>> Find(Expression<Func<T, bool>> expression);
    }
}
