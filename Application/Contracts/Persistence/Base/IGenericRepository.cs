using Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Persistence.Base
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> GetAsync(Guid id, CancellationToken cancellationToken = (default));
        Task<bool> ExistAsync(Guid id, CancellationToken cancellationToken = default);
        Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
        Task<TEntity> FindModelAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default);
        Task<IReadOnlyList<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default);
        Task<bool> IsExistValueAsync(Expression<Func<TEntity, bool>> expression, bool ignoreFilter = false, CancellationToken cancellationToken = default);
    }
}
