using Application.Contracts.Persistence.Base;
using Domain.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Persistence.Repositories.Base
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly RayanbourseDbContext _context;
        protected DbSet<TEntity> Entities { get; }
        protected IQueryable<TEntity> TableNoTracking => Entities.AsNoTracking();
        public GenericRepository(RayanbourseDbContext context)
        {
            _context = context;
            Entities = _context.Set<TEntity>();

        }
        public async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            try
            {
                await _context.AddAsync(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            try
            {
                var entity = await GetAsync(id);
                entity.Deleted = true;
                await UpdateAsync(entity);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> ExistAsync(Guid id, CancellationToken cancellationToken = default)
        {
            try
            {
                var entity = await GetAsync(id, cancellationToken);
                return entity != null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<TEntity> FindModelAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default)
        {
            try
            {
                return await TableNoTracking.FirstOrDefaultAsync(expression, cancellationToken);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<TEntity> GetAsync(Guid id, CancellationToken cancellationToken = default)
        {
            try
            {
                return await TableNoTracking.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IReadOnlyList<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default)
        {
            try
            {
                return await TableNoTracking.Where(expression).ToListAsync(cancellationToken);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> IsExistValueAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default)
        {
            try
            {
                return await TableNoTracking.AnyAsync(expression, cancellationToken);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            try
            {
                _context.Entry(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync(cancellationToken);
                return entity;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
