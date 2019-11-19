using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalaryProposal.Infrastructure.Context;
using SalaryProposal.Infrastructure.Interfaces;
using SalaryProposal.Models.Models;

namespace SalaryProposal.Infrastructure.Repositories
{
    /// <summary></summary>
    public abstract class BaseRepository<T> : IRepository<T> where T : BaseModel
    {
        /// <summary>The context</summary>
        protected readonly DBContext _context;

        /// <summary>Initializes a new instance of the <see cref="BaseRepository{T}"/> class.</summary>
        /// <param name="context">The context.</param>
        protected BaseRepository(DBContext context)
        {
            _context = context;
        }

        /// <summary>Adds the specified entity.</summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public async Task<T> Add(T entity)
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        /// <summary>Updates the specified item.</summary>
        /// <param name="entity"></param>
        public async Task Update(Guid id, T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        /// <summary>Deletes the specified identifier.</summary>
        /// <param name="entity"></param>
        public async Task Delete(Guid id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        /// <summary>Gets the by identifier.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public virtual async Task<T> GetById(Guid id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        /// <summary>Lists all.</summary>
        /// <returns></returns>
        public async Task<List<T>> ListAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        /// <summary>Gets the single by spec.</summary>
        /// <param name="spec">The spec.</param>
        /// <returns></returns>
        public async Task<T> GetSingleBySpec(ISpecification<T> spec)
        {
            var result = await List(spec);
            return result.FirstOrDefault();
        }

        /// <summary>Lists the specified spec.</summary>
        /// <param name="spec">The spec.</param>
        /// <returns></returns>
        public async Task<List<T>> List(ISpecification<T> spec)
        {
            // fetch a Queryable that includes all expression-based includes
            var queryableResultWithIncludes = spec.Includes
                .Aggregate(_context.Set<T>().AsQueryable(),
                    (current, include) => current.Include(include));

            // modify the IQueryable to include any string-based include statements
            var secondaryResult = spec.IncludeStrings
                .Aggregate(queryableResultWithIncludes,
                    (current, include) => current.Include(include));

            // return the result of the query using the specification's criteria expression
            return await secondaryResult
                .Where(spec.Criteria)
                .ToListAsync();
        }
    }
}
