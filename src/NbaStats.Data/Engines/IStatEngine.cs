using System;
using System.Collections.Generic;
using System.Text;
using NbaStats.Data.DataObjects;
using NbaStats.Data.Repositories;
using System.Linq;
using System.Linq.Expressions;


namespace NbaStats.Data.Engines
{
    public interface IStatEngine<TEntity>
    {
        /// <summary>
        /// Saves an Entity to the Database.
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>Saved Entity</returns>
        TEntity Save(TEntity entity);

        /// <summary>
        /// Retrieves a Given Entity from the Database.
        /// </summary>
        /// <param name="id">Primary Key</param>
        /// <returns>Requested Entity</returns>
        TEntity Load(long id);

        /// <summary>
        /// Retrieves all of the Given Entities from the Database.
        /// </summary>
        /// <returns>Queryable of the Given Entity</returns>
        IQueryable<TEntity> LoadAll();

        /// <summary>
        /// Checks if the Provided Entity exists in the Database.
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>Boolean</returns>
        bool Exists(TEntity entity);

        /// <summary>
        /// Executes a Query on the Provided Entities.
        /// </summary>
        /// <param name="expression">Expression</param>
        /// <returns>Queryable of the Entity</returns>
        IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> expression);

        /// <summary>
        /// Deletes a Given Entity from the Database.
        /// </summary>
        /// <param name="entity">Entity</param>
        void Delete(TEntity entity);
    }
}
