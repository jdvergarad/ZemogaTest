using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ZemogaTest.Domain.Models;
using ZemogaTest.Repository.DatabaseContext;

namespace ZemogaTest.Repository.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private DbSet<T> entities;

        public Repository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            entities = _applicationDbContext.Set<T>();
        }

        public async Task Create(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            entities.Add(entity);
            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task Edit(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            entities.Update(entity);
            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task<T> Get(Guid id)
        {
            return await entities.SingleOrDefaultAsync(c => c.Id == id);
        }

        public async Task<List<T>> GetAll()
        {
            return await entities.ToListAsync();
        }
    }
}
