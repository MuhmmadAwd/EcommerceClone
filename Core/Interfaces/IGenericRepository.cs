using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Specifications;

namespace Core.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        public Task<T> GetByIdAsync(int id);
        public Task<IReadOnlyList<T>> GetListAllAsync();
        public Task<T> GetEntityWithspec(ISpecification<T> spec);
        public Task<IReadOnlyList<T>> GetListAsync(ISpecification<T> spec);
    }
}