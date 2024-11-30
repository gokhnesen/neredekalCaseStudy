using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace neredekalCaseStudy.Application.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetByIdAsync(Guid id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(Guid Id);
        Task<IEnumerable<TEntity>> FindyAsync(Expression<Func<TEntity, bool>> predicate);
    }
}
