using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ZemogaTest.Domain.Models;

namespace ZemogaTest.Repository.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<List<T>> GetAll();
        Task<T> Get(Guid id);
        Task Create(T entity);
        Task Edit(T entity);
    }
}
