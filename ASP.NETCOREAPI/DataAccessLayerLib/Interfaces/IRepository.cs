using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayerLib.Interfaces
{
    public interface IRepository<T>
    {
        public IEnumerable<T> GetAll();
        public T GetById(int id);
        public Task<T> Create(T entity);
        public void Update(T entity);   
        public void Delete(T entity);

    }
}
