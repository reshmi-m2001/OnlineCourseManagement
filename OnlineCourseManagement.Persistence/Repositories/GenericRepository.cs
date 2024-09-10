using Microsoft.EntityFrameworkCore;
using OnlineCourseManagement.Application.Contracts.Persistence;
using OnlineCourseManagement.Domain.Common;
using OnlineCourseManagement.Persistence.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCourseManagement.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected readonly ConnectionDatabaseContext _connectionDatabaseContext;

        public GenericRepository(ConnectionDatabaseContext connectionDatabaseContext)
        {
            this._connectionDatabaseContext = connectionDatabaseContext;
        }

        public  async Task CreateAsync(T entity)
        {
            await _connectionDatabaseContext.AddAsync(entity);
            await _connectionDatabaseContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _connectionDatabaseContext.Remove(entity);
            await _connectionDatabaseContext.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<T>> GetAsync()
        {
            return await _connectionDatabaseContext.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _connectionDatabaseContext.Set<T>().AsNoTracking().FirstOrDefaultAsync(q =>q.Id ==id);

        }

        public async Task UpdateAsync(T entity)
        {
           /* _connectionDatabaseContext.Update(entity);*/
            _connectionDatabaseContext.Entry(entity).State = EntityState.Modified;
            await _connectionDatabaseContext.SaveChangesAsync();
        }
    }
}
