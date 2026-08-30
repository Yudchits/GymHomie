using GymHomie.TrainingPlan.Data.Context;
using GymHomie.TrainingPlan.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GymHomie.TrainingPlan.Data.Repositories
{
    internal class Repository<TEntity, TId> : IRepository<TEntity, TId>
        where TEntity : class
    {
        protected readonly TrainingPlanContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public Repository(TrainingPlanContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public virtual async Task<ICollection<TEntity>> GetAllAsync()
        {
            return await _dbSet
                .AsNoTracking()
                .ToListAsync();
        }

        public virtual async Task<TEntity> CreateAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            return entity;
        }

        public virtual Task UpdateAsync(TEntity entity)
        {
            _dbSet.Update(entity);
            return Task.CompletedTask;
        }

        public virtual async Task<bool> DeleteById(TId id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity is null)
                return false;

            _context.Entry(entity).State = EntityState.Deleted;
            return true;
        }

        public virtual async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
