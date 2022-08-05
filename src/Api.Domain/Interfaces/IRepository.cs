using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces
{
    public interface IRepository<T,K> where T: BaseEntity
    {
        Task<T> InsertAsync( T item);
        Task<T> UpdateAsync( T item );
        Task<bool> DeleteAsync(K id );
        Task<T> SelectAsync( K id );
        Task<IEnumerable<T>> SelectAsync();
        Task<bool> ExistAsync( K id );
    }
}