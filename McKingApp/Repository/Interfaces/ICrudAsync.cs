using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace McKingApp.Repository.Interfaces
{
    public interface ICrudAsync<T>
    {
        public Task CreateAsync(T obj);
        public Task DeleteAsync(int id);
        public Task UpdateAsync(T obj);
        public Task<T> ReadAsync (int id);
       public IQueryable<T> ReadAll();

    }
}
