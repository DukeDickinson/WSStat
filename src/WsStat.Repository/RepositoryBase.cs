using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Linq.Expressions;
using WSStat.Common.Logging;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace WSStat.Repository
{
    public abstract class RepositoryBase
    {
        private ILogger _log;

        protected RepositoryBase(ILogger log)
        {
            _log = log;
        }

        /// <summary>
        /// Adds a new item to entities.
        /// </summary>
        /// <param name="entities"></param>
        /// <param name="item"></param>
        /// <param name="predicate">Expression to compare for existance.</param>
        /// <returns>The item that was added.</returns>
        //[SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "For internal use only.")]
        protected T Add<T>(IDbSet<T> entities, T item, Expression<Func<T, bool>> predicate) where T : class
        {
            try
            {
                _log.Information("Add called.", Category.Data);

                T existing = entities.SingleOrDefault(predicate);
                if (existing == null)
                {
                    _log.Information("Adding item to repository.", Category.Data);
                    return entities.Add(item);
                }
                else
                {
                    _log.Information("Item already exists in repository. Not adding.", Category.Data);
                    return existing;
                }
            }
            catch (Exception ex)
            {
                _log.Error("Exception in data access.", ex, Category.Data);
                throw new RepositoryException("Exception while adding data to the repository.", ex);
            }
        }

        protected virtual T Get<T>(IDbSet<T> entities, Expression<Func<T, bool>> predicate) where T : class
        {
            try
            {
                return entities.Where(predicate).SingleOrDefault();
            }
            catch (Exception ex)
            {
                _log.Error("Exception in data access.", ex, Category.Data);
                throw new RepositoryException("Exception in RepositoryBase Get<T>.", ex);
            }
        }

        protected virtual IQueryable<T> GetList<T>(IDbSet<T> entities, Expression<Func<T, bool>> predicate) where T : class
        {
            try
            {
                return entities.Where(predicate);
            }
            catch (Exception ex)
            {
                _log.Error("Exception in data access.", ex, Category.Data);
                throw new RepositoryException("Exception in RepositoryBase Get<T>.", ex);
            }
        }
    }
}
