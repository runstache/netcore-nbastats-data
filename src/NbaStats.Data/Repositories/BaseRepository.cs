using NbaStats.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Reflection;

namespace NbaStats.Data.Repositories
{
    public class BaseRepository
    {
        private readonly SqlContext ctx;
        protected SqlContext Context
        {
            get
            {
                return ctx;
            }
        }

        protected BaseRepository(SqlContext ctx)
        {
            this.ctx = ctx;
        }

        /// <summary>
        /// Base Method for Adding Records to the DB Context.
        /// </summary>
        /// <typeparam name="TEntity">Type Parameter</typeparam>
        /// <param name="entity">Entity to Add</param>
        /// <returns>Resulting Entity</returns>
        protected virtual TEntity Add<TEntity>(TEntity entity) where TEntity : class
        {
            EntityEntry<TEntity> entry = ctx.Set<TEntity>().Add(entity);
            ctx.SaveChanges();
            return entry.Entity;
        }

        /// <summary>
        /// Base Method for Updating an Item in the DB Context.
        /// </summary>
        /// <typeparam name="TEntity">Type Parameter</typeparam>
        /// <param name="entity">Entity to Update</param>
        /// <returns>Resulting Entity</returns>
        protected virtual TEntity Update<TEntity>(TEntity entity) where TEntity : class
        {

            var entry = ctx.Entry(entity);
            IKey key = entry.Metadata.FindPrimaryKey();
            List<object> keyValues = new List<object>();

            foreach(IProperty prop in key.Properties)
            {
                PropertyInfo pi = prop.PropertyInfo;
                keyValues.Add(pi.GetValue(entity));
            }

            var original = ctx.Find<TEntity>(keyValues.ToArray());

            if (!entity.Equals(original))
            {
                ctx.Entry(original).CurrentValues.SetValues(entity);
                ctx.SaveChanges();
            }
            return ctx.Entry(entity).Entity;
        }      

        /// <summary>
        /// Base Method to Remove an Item in the Db Context.
        /// </summary>
        /// <typeparam name="TEntity">Type Parameter</typeparam>
        /// <param name="entity">Entity to Remove</param>
        protected virtual void Delete<TEntity>(TEntity entity) where TEntity : class
        {
            ctx.Set<TEntity>().Remove(entity);
            ctx.SaveChanges();
        }
    }
}
