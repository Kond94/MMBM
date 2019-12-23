using System.Collections.Generic;

namespace mmbm.Core.Models
{
    public class QueryResult<T>
    {
        public int TotalItems { get; set; }

        public IEnumerable<T> Items { get; set; }
    }
}