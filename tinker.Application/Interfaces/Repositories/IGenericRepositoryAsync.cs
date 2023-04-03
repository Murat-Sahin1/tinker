using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using tinker.Domain.Entities.Common;

namespace tinker.Application.Interfaces.Repositories
{
    public interface IGenericRepositoryAsync<T> : IRepository<T> where T : BaseEntity
    {
        // Read
        IQueryable<T> GetAll();
        Task<T> GetByIdAsync(int id);
        Task<T> GetSingleAsync(Expression<Func<T, bool>> expression);
        IQueryable<T> GetWhere(Expression<Func<T, bool>> expression);
        // Write
        Task<bool> InsertAsync(T entity);
        Task<bool> InsertRangeAsync(List<T> entities);
        bool Update(T entity);
        bool UpdateRange(List<T> entities);
        bool Remove(T entity);
        Task<bool> RemoveById(int id);
        bool RemoveRange(List<T> entities);
        Task<bool> SaveAsync();
    }
}
