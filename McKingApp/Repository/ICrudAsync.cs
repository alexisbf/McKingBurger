using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace McKingApp.Repository
{
    public interface ICrudAsync<T>
    {
        public Task<T> ReadAsync (int id);

        public IQueryable<T> ReadAll();

    }
}
