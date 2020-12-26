using Data.Abstract;
using Data.IncludeLibrary;
using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebBuilderExceptionLibrary;

namespace Data.Concrete
{
    /// <summary>
    /// Here generic repository pattern is used. 
    /// The purpose of use is to ensure that all objects are managed from a single point. 
    /// If a special method is to be written to the Object, this method should be implemented in dataacces as abstract or interface.
    /// </summary>
    /// <typeparam name="TRepository"></typeparam>
    /// <typeparam name="TEntity"></typeparam>
    public class DataAccessGlobalTemplate<TRepository, TEntity> : IDataAccesLayer<TEntity> where TRepository : DbContext, new() where TEntity : BaseEntity
    {
        public virtual string Language { get; set; }

        /// <summary>
        /// Add specified entity in database asynchronously.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual async Task AddAsync(TEntity entity)
        {
            using (TRepository Context = new TRepository())
            {
                var state = Context.Entry(entity);
                state.State = EntityState.Added;
                await Context.SaveChangesAsync().ConfigureAwait(false);
            }
        }
        /// <summary>
        /// Add specified entity in database asynchronously.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual async Task AddAsync(IEnumerable<TEntity> entity)
        {
            using (TRepository Context = new TRepository())
            {
                var state = Context.Entry(entity);
                state.State = EntityState.Added;
                await Context.SaveChangesAsync().ConfigureAwait(false);
            }
        }
        /// <summary>
        /// Updates specified entity in database asynchronously.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual async Task UpdateAsync(TEntity entity)
        {

            using (TRepository Context = new TRepository())
            {
                var state = Context.Entry(entity);
                state.State = EntityState.Modified;
                await Context.SaveChangesAsync().ConfigureAwait(false);
            }

        }

        /// <summary>
        /// Updates multiple entities in database asynchronously.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public virtual async Task UpdateAsync(IEnumerable<TEntity> entities)
        {
            using (TRepository Context = new TRepository())
            {
                var state = Context.Entry(entities);
                state.State = EntityState.Modified;
                await Context.SaveChangesAsync().ConfigureAwait(false);
            }

        }

        /// <summary>
        /// Deletes single entity from database asynchronously.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual async Task DeleteAsync(TEntity entity)
        {
            using (TRepository Context = new TRepository())
            {
                entity.isDelete = true;
                var state = Context.Entry(entity);
                state.State = EntityState.Modified;
                await Context.SaveChangesAsync().ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Deletes multiple entity from database asynchronously.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public virtual async Task DeleteAsync(IEnumerable<TEntity> entities)
        {
            entities.ToList().ForEach(
                x =>
                {
                    x.isDelete = true;
                }
                );
            using (TRepository Context = new TRepository())
            {
                var state = Context.Entry(entities);
                state.State = EntityState.Modified;
                await Context.SaveChangesAsync().ConfigureAwait(false);
            }
        }


        /// <summary>
        ///  Returns all entities which active condition is true from database asynchronously.
        /// If the condition is requested, it also provides that condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public virtual async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> condition = null)
        {
            
            using (TRepository Context = new TRepository())
            {
                var q=
                 await Context.Set<TEntity>().Where(entity => entity.isDelete == false)
                .Where(condition ?? (entity => true))
                .ToListAsync()
                .ConfigureAwait(false) ?? throw new CannotFindEntityException();
                return q;
            }
        }
        /// <summary>
        /// Returns one entity by entity Id from database asynchronously.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual async Task<TEntity> GetByIdAsync(int id)
        {
            using (TRepository Context = new TRepository())
            {
                if (id == 0) throw new CannotFindEntityException(id);
                var entity = await Context.Set<TEntity>().Where(x => x.isDelete == false && x.Id == id).FirstOrDefaultAsync().ConfigureAwait(false) ?? throw new CannotFindEntityException(id);
                //if (!entity.Active) throw new CannotFindEntityException($"{id} idsine sahip entity aktif degil.");
                return entity;
            }
        }

        public virtual async Task<TEntity> Get(Expression<Func<TEntity, bool>> condition = null)
        {
            using (TRepository Context = new TRepository())
            {

                return await Context.Set<TEntity>().Where(entity => entity.isDelete == false)
            .Where(condition ?? (entity => true))
            .FirstOrDefaultAsync()
            .ConfigureAwait(false);

            }
        }

        /// <summary>
        /// Executes sql query to database asynchronously.(e.g. trigger, event) 
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        //public async Task ExecuteQueryAsync(string query)
        //{
        //    await Database.ExecuteSqlRawAsync(query).ConfigureAwait(false);
        //}
    }
}
