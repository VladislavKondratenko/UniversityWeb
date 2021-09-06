using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using University.Domain.Core;

namespace University.Infrastructure.Interfaces
{
    public interface IRepository<TEntity> where TEntity : EntityBaseModel
    {
        Task CreateAsync(TEntity model);
        Task<TEntity> GetByIdAsync(int id);
        Task<IEnumerable<TEntity>> GetListAsync();
        Task EditAsync(TEntity model);
        Task DeleteAsync(TEntity model);
        Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate);
    }
}