using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace YConnectBackend.Domain.Commons.Database
{
    public interface IRepository<AggregateRoot, TContext> where AggregateRoot : IAggregateRoot
    {
        ICollection<string> Includes { get; set; }
        Task<AggregateRoot> FindAsync(Expression<Func<AggregateRoot, bool>> func);
        Task<AggregateRoot> FindAndReloadAsync(Expression<Func<AggregateRoot, bool>> func);
        Task<AggregateRoot> FindReadOnlyAsync(Expression<Func<AggregateRoot, bool>> func);
        Task<TReturn> FindReadOnlyAsync<TReturn>(Expression<Func<AggregateRoot, bool>> func);
        Task<AggregateRoot> AddAsync(AggregateRoot entity);
        Task AddRangeAsync(IEnumerable<AggregateRoot> entities);
        Task<AggregateRoot> UpdateAsync(AggregateRoot entity);

        Task<ICollection<AggregateRoot>> FilterAsync(Expression<Func<AggregateRoot, bool>> func);
        Task<ICollection<TReturn>> FilterReadOnlyAsync<TReturn>(Expression<Func<AggregateRoot, bool>> func);
       
    }
}