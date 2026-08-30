using System.Collections.Generic;
using System.Threading.Tasks;

namespace GymHomie.TrainingPlan.Domain.Repositories
{
    public interface IRepository<TEntity, TId>
        where TEntity : class
    {
        Task<ICollection<TEntity>> GetAllAsync();
        Task<TEntity> CreateAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task<bool> DeleteById(TId id);
        Task<int> SaveChangesAsync();
    }
}
