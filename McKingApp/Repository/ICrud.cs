using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace McKingApp.Repository
{
    public interface ICrud<T>
    {
        public void Create(T obj);
        public void Delete(int id);
        public void Update(T obj);
        public T Read(int id);
        public IQueryable<T> ReadAll();
    }
}
