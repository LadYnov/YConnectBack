using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using YConnectBackend.Domain.Commons;
using YConnectBackend.Domain.Commons.Database;

namespace YConnectBackend.Infrastructure.Adapters.database
{
    public class EfRepository<AggregateRoot, TContext> : IRepository<AggregateRoot, TContext>, IDisposable
        where AggregateRoot : class, IAggregateRoot
        where TContext : YDbContext
    {
        private readonly TContext _context;
        private readonly DbSet<AggregateRoot> _entities;
        private readonly IConfigurationProvider _configuration;

        private IQueryable<AggregateRoot> ReadonlyEntities => _entities.AsNoTracking();
        public ICollection<string> Includes { get; set; } = new List<string>();

        private IDbContextTransaction _transaction;

        public EfRepository(TContext context, IConfigurationProvider configuration)
        {
            this._context = context;

            this._entities = _context.Set<AggregateRoot>();
            _configuration = configuration;
        }

        public async Task<AggregateRoot> AddAsync(AggregateRoot entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<AggregateRoot> FindAsync(Expression<Func<AggregateRoot, bool>> func)
        {
            IQueryable<AggregateRoot> query = _entities;

            foreach (string include in Includes)
            {
                query = query.Include(include);
            }

            return await query.SingleOrDefaultAsync(func);
        }

        public async Task<AggregateRoot> FindAndReloadAsync(Expression<Func<AggregateRoot, bool>> func)
        {
            AggregateRoot entity = await FindAsync(func).ConfigureAwait(false);

            _context.Entry(entity).State = EntityState.Detached;
            return await FindAsync(func).ConfigureAwait(false);
        }

        public async Task<AggregateRoot> UpdateAsync(AggregateRoot entity)
        {
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<AggregateRoot> FindReadOnlyAsync(Expression<Func<AggregateRoot, bool>> func)
        {
            IQueryable<AggregateRoot> query = GenerateQuery(ReadonlyEntities.AsQueryable(), func);

            foreach (string include in Includes)
            {
                query = query.Include(include);
            }

            return await query.SingleOrDefaultAsync();
        }

        public async Task<TReturn> FindReadOnlyAsync<TReturn>(Expression<Func<AggregateRoot, bool>> func) =>
            await GenerateQuery(ReadonlyEntities, func)
                .ProjectTo<TReturn>(_configuration).SingleOrDefaultAsync();

        private IQueryable<AggregateRoot> GenerateQuery(IQueryable<AggregateRoot> entities,
            Expression<Func<AggregateRoot, bool>> func) => entities.Where(func);

        public async Task<ICollection<AggregateRoot>> FilterAsync(Expression<Func<AggregateRoot, bool>> func)
        {
            IQueryable<AggregateRoot> query = GenerateQuery(_entities, func);

            foreach (string include in Includes)
            {
                query = query.Include(include);
            }

            return await query.ToListAsync();
        }

        public async Task<ICollection<TReturn>>
            FilterReadOnlyAsync<TReturn>(Expression<Func<AggregateRoot, bool>> func) =>
            await GenerateQuery(ReadonlyEntities, func).ProjectTo<TReturn>(_configuration).ToListAsync();


        public async Task AddRangeAsync(IEnumerable<AggregateRoot> entities)
        {
            await _entities.AddRangeAsync(entities);
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            if (_transaction != null)
            {
                _transaction.Dispose();
            }

            _context?.Dispose();
        }

        public async Task RollbackAsync()
        {
            await _transaction.RollbackAsync();
        }

        public async Task CommitAsync()
        {
            await _transaction.CommitAsync();
        }

        public Task<int> CountAsync(Expression<Func<AggregateRoot, bool>> func) =>
            GenerateQuery(ReadonlyEntities, func).CountAsync();
    }
}