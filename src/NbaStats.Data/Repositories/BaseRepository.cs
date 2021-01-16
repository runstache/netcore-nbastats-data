using NbaStats.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.ChangeTracking;


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
        /// <typeparam name="T">Type Parameter</typeparam>
        /// <param name="entity">Entity to Add</param>
        /// <returns>Resulting Entity</returns>
        protected virtual T Add<T>(T entity) where T : class
        {
            EntityEntry<T> entry = ctx.Set<T>().Add(entity);
            ctx.SaveChanges();
            return entry.Entity;
        }

        /// <summary>
        /// Base Method for Updating an Item in the DB Context.
        /// </summary>
        /// <typeparam name="T">Type Parameter</typeparam>
        /// <param name="entity">Entity to Update</param>
        /// <returns>Resulting Entity</returns>
        protected virtual T Update<T>(T entity) where T : class
        {
            var original = ctx.Entry(entity);
            if (!entity.Equals(original.Entity))
            {
                ctx.Entry(original).CurrentValues.SetValues(entity);
                ctx.SaveChanges();
            }
            return ctx.Entry(entity).Entity;
        }      
    }
}
