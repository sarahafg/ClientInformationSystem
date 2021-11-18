using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ApplicationCore.RepositoryInterfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class EfRepository<T> : IAsyncRepository<T> where T : class
    {
        protected readonly ClientInformationSystemDbContext clientInformationSystemDbContext;

        public EfRepository(ClientInformationSystemDbContext dbContext)
        {
            clientInformationSystemDbContext = dbContext;
        }

        public async Task<T> GetById(int id)
        {
            var entity = await clientInformationSystemDbContext.Set<T>().FindAsync(id);
            return entity;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            var data = await clientInformationSystemDbContext.Set<T>().ToListAsync();
            return data;
        }

        public async Task<IEnumerable<T>> Get(Expression<Func<T, bool>> predicate)
        {
            return await clientInformationSystemDbContext.Set<T>().Where(predicate).ToListAsync();
        }

        public async Task<int> GetCount(Expression<Func<T, bool>> predicate)
        {
            return await clientInformationSystemDbContext.Set<T>().CountAsync();
        }

        public async Task<T> Add(T entity)
        {
            await clientInformationSystemDbContext.Set<T>().AddAsync(entity);
            await clientInformationSystemDbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<T> Update(T entity)
        {
            clientInformationSystemDbContext.Entry(entity).State = EntityState.Modified;
            await clientInformationSystemDbContext.SaveChangesAsync();
            return entity;
        }

        public async Task Delete(T entity)
        {
            clientInformationSystemDbContext.Set<T>().Remove(entity);
            await clientInformationSystemDbContext.SaveChangesAsync();
        }
    }
}
