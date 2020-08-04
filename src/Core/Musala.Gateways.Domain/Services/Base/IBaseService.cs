using System.Collections.Generic;
using System.Threading.Tasks;
using Musala.Gateways.Data.Entity.Base;

namespace Musala.Gateways.Domain.Services.Base
{
    public interface IBaseService<T, K> where T : Entity<K>
    {
        Task<T> CreateAsync(T data);
        Task<T> UpdateAsync(T data);
        Task<T> GetByIdAsync(K id);
        Task DeleteAsync(T data);

        Task<IEnumerable<T>> GetAll();
    }
}
