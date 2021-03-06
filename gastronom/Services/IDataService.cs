using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace gastronom.Services
{
    public interface IDataService<T>
    {
        Task<IEnumerable<T>> GetAll();

        Task<T> Get(long id);

        Task<T> Create(T entity);

        Task<T> Update(long id, T entity);

        Task<bool> Delete(long id);
    }
}
