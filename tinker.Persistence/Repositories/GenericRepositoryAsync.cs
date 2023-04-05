using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using tinker.Application.Interfaces.Repositories;
using tinker.Domain.Entities.Common;
using tinker.Persistence.Contexts;

namespace tinker.Persistence.Repositories
{
    public class GenericRepositoryAsync<T> : IGenericRepositoryAsync<T> where T : BaseEntity
    {
        private readonly AppDbContext _appDbContext;
        public GenericRepositoryAsync(AppDbContext dbContext)
        {
            _appDbContext = dbContext;
        }

        // Read
        public DbSet<T> Table => _appDbContext.Set<T>();

        public IQueryable<T> GetAll()
        {
            IQueryable<T> entities = Table.AsQueryable();
            return entities;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await Table.FindAsync(id);
        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> expression)
        {
            var query = Table.AsQueryable();
            return await query.FirstOrDefaultAsync(expression);
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> expression)
        {
            var query = Table.Where(expression);
            return query;
        }

        // Write
        public async Task<bool> InsertAsync(T entity)
        {
            EntityEntry<T> entityEntry = await Table.AddAsync(entity);
            return entityEntry.State == EntityState.Added;
        }

        public async Task<bool> InsertRangeAsync(List<T> entities)
        {
            await Table.AddRangeAsync(entities);
            return true;
        }

        public bool Remove(T entity)
        {
            EntityEntry<T> entityEntry = Table.Remove(entity);
            return entityEntry.State == EntityState.Deleted;
        }

        public async Task<bool> RemoveById(int id)
        {
            T foundEntity = await Table.FindAsync(id);
            EntityEntry<T> entityEntry = Table.Remove(foundEntity);
            return entityEntry.State == EntityState.Deleted;
        }

        public bool RemoveRange(List<T> entities)
        {
            Table.RemoveRange(entities);

            return true;
        }
        public bool Update(T entity)
        {
            EntityEntry<T> entityEntry = Table.Update(entity);
            return entityEntry.State == EntityState.Modified;
        }

        public bool UpdateRange(List<T> entities)
        {
            Table.UpdateRange(entities);
            return true;
        }

        public async Task<bool> SaveAsync()
        {
            await _appDbContext.SaveChangesAsync();
            return true;
        }
        public bool AnyElements()
        {
            bool isSeeded = Table.Any();
            return isSeeded;
        }
        public bool EnsureCreation()
        {
            bool isCreated = _appDbContext.Database.EnsureCreated();
            return isCreated;
        }
    }
}
