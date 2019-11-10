using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackEndExamen1.Data.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
         Task<IEnumerable<T>> GetAll();
         Task Add(T entity);         
         Task Delete(object id);
         Task<T> GetById(object id);          
         T Update(int id, T entity);
    }
}