using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SalaryProposal.Infrastructure.Interfaces
{
    /// <summary></summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="System.IDisposable" />
    public interface IRepository<T> where T : class
    {
        /// <summary>Gets the by identifier.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<T> GetById(Guid id);

        /// <summary>Lists all.</summary>
        /// <returns></returns>
        Task<List<T>> ListAll();

        /// <summary>Gets the single by spec.</summary>
        /// <param name="spec">The spec.</param>
        /// <returns></returns>
        Task<T> GetSingleBySpec(ISpecification<T> spec);

        /// <summary>Lists the specified spec.</summary>
        /// <param name="spec">The spec.</param>
        /// <returns></returns>
        Task<List<T>> List(ISpecification<T> spec);

        /// <summary>Adds the specified entity.</summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        Task<T> Add(T entity);

        /// <summary>Updates the specified item.</summary>
        /// <param name="item">The item.</param>
        Task Update(Guid id, T entity);

        /// <summary>Deletes the specified identifier.</summary>
        /// <param name="id">The identifier.</param>
        Task Delete(Guid id);
    }
}
