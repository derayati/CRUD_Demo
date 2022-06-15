using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DerayatiBank.Core.Interfaces
{
    public interface IRepository<T>
    {
        public Task<T> Create(T _object);

        public void Update(T _object);

        public IEnumerable<T> GetAll();

        public T GetById(Guid Id);

        public Task<T> GetByIdAsync(Guid Id);

        //public IEnumerable<T> GetAllAsync();
        public Task<IEnumerable<T>> GetAllAsync();

        public void Delete(T _object);
    }
}
