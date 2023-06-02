﻿using core.Models;
using Data.Context;
using Microsoft.EntityFrameworkCore;
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

        public async Task Atualizar(TEntity entity)
        {
            _DbSet.Update(entity);
            await _AppDbContext.SaveChangesAsync();
        }

        async Task<ICollection<TEntity>> IRepositoryBase<TEntity>.Obter(Expression<Func<TEntity, bool>> filter)
        {
            var query = _DbSet.AsQueryable();

            if (filter != null)
                query = query
                    .Where(filter)
                    .AsNoTracking();

            return await query.ToListAsync();
        }
    }
}
