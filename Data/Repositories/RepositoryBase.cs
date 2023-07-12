using core.Models;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : Entity
    {
        public readonly DbSet<TEntity> _DbSet;
        public readonly AppDbContext _AppDbContext;
        public RepositoryBase(AppDbContext appContext)
        {
            _DbSet = appContext.Set<TEntity>();
            _AppDbContext = appContext;
        }

        public async Task<TEntity> ObterObj(Expression<Func<TEntity, bool>> filter = null)
        {
            var query = _DbSet.AsQueryable();

            if (filter != null)
                query = query
                    .Where(filter)
                    .AsNoTracking();

            return await query.FirstOrDefaultAsync();
        }

        public async Task<ICollection<TEntity>> ObterListAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            var query = _DbSet.AsQueryable();

            if (filter != null)
                query = query
                    .Where(filter)
                    .AsNoTracking();

            return await query.ToListAsync();
        }

        public async Task<ICollection<TEntity>> Obter(Expression<Func<TEntity, bool>> filter = null)
        {
            var query = _DbSet.AsQueryable();

            if (filter != null)
                query = query
                    .Where(filter)
                    .AsNoTracking();

            return await query.ToListAsync();
        }

        public async Task<TEntity> ObterPorIdAsync(int id)
        {
            return await _DbSet.FindAsync(id);
        }

        public TEntity Add(TEntity entity)
        {
            _DbSet.AddAsync(entity);
            _AppDbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _DbSet.AddAsync(entity);
            await _AppDbContext.SaveChangesAsync();

            return entity;
        }

        public async Task DeletarAsync(TEntity entity)
        {
            _DbSet.Remove(entity);
            await _AppDbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Performs an update for the value (reselects and/or automatically saves changes where specified).
        /// </summary>
        /// <typeparam name="T">The resultant <see cref="Type"/>.</typeparam>
        /// <typeparam name="TModel">The entity framework model <see cref="Type"/>.</typeparam>
        /// <param name="args">The <see cref="EfDbArgs"/>.</param>
        /// <param name="value">The value to insert.</param>
        /// <returns>The value (refreshed where specified).</returns>
        public async Task<T> UpdateAsync<T, TModel>(EfDbArgs args, T value) where T : class, new() where TModel : class, new()
        {
            CheckSaveArgs<T, TModel>(args);

            //if (value == null)
            //    throw new ArgumentNullException(nameof(value));

            //if (value is IChangeLog cl)
            //{
            //    if (cl.ChangeLog == null)
            //        cl.ChangeLog = new ChangeLog();

            //    cl.ChangeLog.UpdatedBy = ExecutionContext.HasCurrent ? ExecutionContext.Current.Username : ExecutionContext.EnvironmentUsername;
            //    cl.ChangeLog.UpdatedDate = ExecutionContext.HasCurrent ? ExecutionContext.Current.Timestamp : Cleaner.Clean(DateTime.Now);
            //}

            return await Invoker.InvokeAsync(this, async () =>
            {
                // Check (find) if the entity exists.
                var efKeys = GetEfKeys(value);

                var model = (TModel)await DbContext.FindAsync(typeof(TModel), efKeys).ConfigureAwait(false);
                if (model == null)
                    throw new NotFoundException();

                // Remove the entity from the tracker before we attempt to update; otherwise, will use existing rowversion and concurrency will not work as expected.
                DbContext.Remove(model);
                DbContext.ChangeTracker.AcceptAllChanges();

                args.Mapper.Map<T, TModel>(value, model, Mapper.OperationTypes.Update);

                DbContext.Update(model);

                if (args.SaveChanges)
                    await DbContext.SaveChangesAsync(true).ConfigureAwait(false);

                return args.Refresh ? args.Mapper.Map<TModel, T>(model, Mapper.OperationTypes.Get)! : value;
            }, this).ConfigureAwait(false);
        }

        public async Task<TEntity> Atualizar(TEntity entity)
        {
            int idPessoaUpdate = 0;
            _DbSet.Update(entity);
            _AppDbContext.ChangeTracker.AcceptAllChanges();
            idPessoaUpdate = await _AppDbContext.SaveChangesAsync();

            

            return await _AppDbContext.FindAsync<TEntity>(idPessoaUpdate);
        }
    }
}
