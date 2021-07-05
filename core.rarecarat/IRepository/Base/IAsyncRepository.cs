//using Kendo.Mvc.UI;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace core.rarecarat
{
    public interface IAsyncRepository<T> where T : IEntity
    {
        Task<object> CreateAsync( T entity );

        Task UpdateAsync( T entity );

        Task DeleteAsync( object id );

        ValueTask<T> GetByIdAsync( object id );
    }
}