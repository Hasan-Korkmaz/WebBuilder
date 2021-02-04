using Data.IncludeLibrary;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Abstract
{
    public interface IDataAccesLayer<TEntity> where TEntity : BaseEntity
    {

        /// <summary>
        /// Returns all entities which active condition is true from database asynchronously.
        /// If the condition is requested, it also provides that condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> condition = null);
        /// <summary>
        /// This code returns the first object it finds
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        Task<TEntity> Get(Expression<Func<TEntity, bool>> condition = null);

        /// <summary>
        /// Returns one entity by entity Id from database asynchronously.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TEntity> GetByIdAsync(int id);

        /// <summary>
        /// Updates specified entity in database asynchronously.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task UpdateAsync(TEntity entity);

        /// <summary>
        /// Updates multiple entities in database asynchronously.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        Task UpdateAsync(IEnumerable<TEntity> entities);

        /// <summary>
        /// Deletes single entity from database asynchronously.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task DeleteAsync(TEntity entity);
        /// <summary>
        /// Deletes multiple entity from database asynchronously.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        Task DeleteAsync(IEnumerable<TEntity> entities);
        Task DeleteExpression(Expression<Func<TEntity, bool>> condition );
        Task AddAsync(TEntity entity);
        string Language { get; set; }
    }
}
