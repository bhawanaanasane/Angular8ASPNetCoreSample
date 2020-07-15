using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FLA.Core;

namespace FLA.Data.Interfaces
{
    public interface IAsyncRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(long id);
        Task<List<T>> ListAllAsync();
        Task<List<T>> ListAsync(ISpecification<T> spec);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        List<T> ExecuteSP(string query, params object[] parameters);
    }
}
