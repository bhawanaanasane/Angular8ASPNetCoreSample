﻿using FLA.Core;
using FLA.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLA.Data
{
   public  class EfRepository <T> : IRepository<T>, IAsyncRepository<T> where T : BaseEntity
    {
        protected readonly DBContextFLA _dbContext;
        private DbSet<T> _entities;


        public EfRepository(DBContextFLA context)
        {
            this._dbContext = context;
        }

        /// <summary>
        /// Get entity by identifier
        /// </summary>
        /// <param name="id">Identifier</param>
        /// <returns>Entity</returns>
        public virtual T GetById(object id)
        {
            //see some suggested performance optimization (not tested)
            //http://stackoverflow.com/questions/11686225/dbset-find-method-ridiculously-slow-compared-to-singleordefault-on-id/11688189#comment34876113_11688189
            return Entities.Find(id);
        }
        public virtual IQueryable<T> Table
        {
            get
            {
                return Entities;
            }
        }
        public virtual void Insert(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException(nameof(entity));

                Entities.Add(entity);

                _dbContext.SaveChanges();
            }
            catch (Exception dbEx)
            {
                //ensure that the detailed error text is saved in the Log
                throw new Exception(dbEx.ToString());
            }
        }

        public void Insert(IEnumerable<T> entities)
        {
            try
            {
                if (entities == null)
                    throw new ArgumentNullException(nameof(entities));

                foreach (var entity in entities)
                    Entities.Add(entity);

                _dbContext.SaveChanges();
            }
            catch (Exception dbEx)
            {
                //ensure that the detailed error text is saved in the Log
                throw new Exception(dbEx.ToString());
            }
        }
        public virtual void Update(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException(nameof(entity));
                _dbContext.Entry(entity).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch (Exception dbEx)
            {
                //ensure that the detailed error text is saved in the Log
                throw new Exception(dbEx.ToString());
            }
        }
        public void Update(IEnumerable<T> entities)
        {
            try
            {
                if (entities == null)
                    throw new ArgumentNullException(nameof(entities));
                _dbContext.Entry(entities).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch (Exception dbEx)
            {
                //ensure that the detailed error text is saved in the Log
                throw new Exception(dbEx.ToString());
            }
        }

        /// <summary>
        /// Delete entity
        /// </summary>
        /// <param name="entity">Entity</param>
        public virtual void Delete(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException(nameof(entity));

                Entities.Remove(entity);

                _dbContext.SaveChanges();
            }
            catch (Exception dbEx)
            {
                //ensure that the detailed error text is saved in the Log
                throw new Exception(dbEx.ToString());
            }
        }

        /// <summary>
        /// Delete entities
        /// </summary>
        /// <param name="entities">Entities</param>
        public virtual void Delete(IEnumerable<T> entities)
        {
            try
            {
                if (entities == null)
                    throw new ArgumentNullException(nameof(entities));

                foreach (var entity in entities)
                    Entities.Remove(entity);

                _dbContext.SaveChanges();
            }
            catch (Exception dbEx)
            {
                //ensure that the detailed error text is saved in the Log
                throw new Exception(dbEx.ToString());
            }
        }

        public async Task<T> GetByIdAsync(long id)
        {
            return await Entities.FindAsync(id);
        }

        public Task<List<T>> ListAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> ListAsync(ISpecification<T> spec)
        {
            throw new NotImplementedException();
        }

        public Task<T> AddAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(T entity)
        {
            throw new NotImplementedException();
        }

        //store procedure
        public List<T> ExecuteSP(string query, params object[] parameters)
        {
            var type = _dbContext.Set<T>().FromSqlRaw(query, parameters).AsNoTracking().ToList<T>(); return type;
        }
        //store procedure
        public void ExecuteCammandSP(string query, params object[] parameters)
        {
            var type = _dbContext.Database.ExecuteSqlCommand(query, parameters);
        }

        /// <summary>
        /// Entities
        /// </summary>
        protected virtual DbSet<T> Entities
        {
            get
            {
                if (_entities == null)
                    _entities = _dbContext.Set<T>();
                return _entities;
            }
        }


    }
}
