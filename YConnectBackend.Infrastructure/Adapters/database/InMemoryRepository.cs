

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using YConnectBackend.Domain.Commons;
using YConnectBackend.Domain.Commons.Database;
using YConnectBackend.DomainShared.Commons.Models;

namespace YConnectBackend.Infrastructure.Adapters.database
{
     public class InMemoryRepository<AggregateRoot, TContext> : IRepository<AggregateRoot, TContext>
        where AggregateRoot : class, IAggregateRoot
    {
        
        private readonly IConfigurationProvider _configuration;
        
        private ImmutableList<AggregateRoot> _entities;

        private IReadOnlyList<AggregateRoot> Entities => _entities;

        public ICollection<string> Includes { get; set; } = new List<string>();

        public InMemoryRepository(IConfigurationProvider configuration)
        {
            _entities = new List<AggregateRoot>().ToImmutableList();
            _configuration = configuration;
        }

        private IQueryable<AggregateRoot> GenerateQuery(Expression<Func<AggregateRoot, bool>> func) =>
            Entities.AsQueryable().Where(func);

        public async Task<AggregateRoot> FindAsync(Expression<Func<AggregateRoot, bool>> func)
        {
            AggregateRoot? result = GenerateQuery(func).SingleOrDefault();
            return await Task.FromResult(result);
        }

        public Task<AggregateRoot> FindAndReloadAsync(Expression<Func<AggregateRoot, bool>> func) => FindAsync(func);

        public Task<AggregateRoot> AddAsync(AggregateRoot entity)
        {
            _entities = new List<AggregateRoot>(_entities.Add(entity)).ToImmutableList();
            return Task.FromResult(entity);
        }

        public void Clear()
        {
            _entities = new List<AggregateRoot>(_entities.RemoveAll(_ => true)).ToImmutableList();
        }

        public Task<AggregateRoot> UpdateAsync(AggregateRoot entity)
        {
            AggregateRoot aggregateRoot = Entities.Single(s => s.Id == entity.Id);
            _entities = new List<AggregateRoot>(_entities.Remove(aggregateRoot)).ToImmutableList();
            _entities = new List<AggregateRoot>(_entities.Add(entity)).ToImmutableList();

            return Task.FromResult(entity);
        }
        
        public async Task<AggregateRoot> FindReadOnlyAsync(Expression<Func<AggregateRoot, bool>> func) => await Task.FromResult(GenerateQuery(func).SingleOrDefault());

        public async Task<TReturn> FindReadOnlyAsync<TReturn>(Expression<Func<AggregateRoot, bool>> func) => await Task.FromResult(GenerateQuery(func).ProjectTo<TReturn>(_configuration).SingleOrDefault());

        public async Task<ICollection<TReturn>> FilterReadOnlyAsync<TReturn>(Expression<Func<AggregateRoot, bool>> func) => await Task.FromResult(GenerateQuery(func).ProjectTo<TReturn>(_configuration).ToList());
        
        public async Task<PaginatedResult<AggregateRoot>> FilterReadOnlyAsync(
            Expression<Func<AggregateRoot, bool>> func, int take, int skip)
        {
            List<AggregateRoot> result = await Task.FromResult(GenerateQuery(func).Skip(skip)
                .Take(take).ToList());
            int count = GenerateQuery(x => true).Count();

            return new PaginatedResult<AggregateRoot>((uint) count, result);
        }
        
        public async Task<ICollection<AggregateRoot>> FilterAsync(Expression<Func<AggregateRoot, bool>> func) => await Task.FromResult(GenerateQuery(func).ToList());

        public async Task AddRangeAsync(IEnumerable<AggregateRoot> entities)
        {
            foreach (AggregateRoot entity in entities)
            {
                await AddAsync(entity);
            }
        }

        public Task RollbackAsync() => Task.CompletedTask;

        public Task CommitAsync() => Task.CompletedTask;

        public async Task<int> CountAsync(Expression<Func<AggregateRoot, bool>> func) => await Task.FromResult(GenerateQuery(func).Count());
    }
}