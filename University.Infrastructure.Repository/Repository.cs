using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using University.Domain.Core;
using University.Infrastructure.Data;
using University.Infrastructure.Interfaces;

namespace University.Infrastructure.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : EntityBaseModel
    {
        private readonly UniversityContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public Repository(UniversityContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public async Task CreateAsync(TEntity model)
        {
            await _dbSet.AddAsync(model);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(TEntity model)
        {
            if (model != null)
                _dbSet.Remove(model);

            await _context.SaveChangesAsync();
        }

        public async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.FirstOrDefaultAsync(predicate);
        }

        public async Task EditAsync(TEntity model)
        {
            _dbSet.Update(model);

            await _context.SaveChangesAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _dbSet.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<IEnumerable<TEntity>> GetListAsync()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }
    }
}