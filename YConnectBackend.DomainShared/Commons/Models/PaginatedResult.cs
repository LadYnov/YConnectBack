using System.Collections.Generic;

namespace YConnectBackend.DomainShared.Commons.Models
{
    public class PaginatedResult<T>
    {
        public uint Count { get; set; }
        public ICollection<T> Result { get; set; }

        public PaginatedResult(uint count, ICollection<T> result)
        {
            Count = count;
            Result = result;
        }

        public PaginatedResult()
        {
            Result = new List<T>();
        }

        public bool Any() => Count > 0;
    }
}
