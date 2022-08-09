using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Data.Content;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Repository
{
    public class BaseRepository<T, K> : IRepository<T, K> where T : BaseEntity
    {
        protected readonly MyContext _context;

        private DbSet<T> _dataSet;

        public BaseRepository(MyContext context)
        {
            _context = context;
            _dataSet = _context.Set<T>();

        }


        public async Task<bool> DeleteAsync(K id)
        {
            var result = await _dataSet.SingleOrDefaultAsync(p => p.Id.Equals(id));

            if (result == null)
                return false;

            _dataSet.Remove(result);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<T> InsertAsync(T item)
        {
            item.CreatedAt = DateTime.UtcNow;

            _dataSet.Add(item);

            await _context.SaveChangesAsync();


            return item;

        }

        public async Task<IEnumerable<T>> SelectAsync()
        {
            return await _dataSet.ToListAsync();

        }

        public async Task<T> SelectAsync(K id)
        {
            return await _dataSet.SingleOrDefaultAsync(p => p.Id.Equals(id));

        }

        public async Task<T> UpdateAsync(T item)
        {
            var result = await _dataSet.SingleOrDefaultAsync(p => p.Id.Equals(item.Id));

            if (result == null)
                return null;

            item.UpdateAt = DateTime.UtcNow;
            item.CreatedAt = result.CreatedAt;

            _context.Entry(result).CurrentValues.SetValues(item);

            await _context.SaveChangesAsync();


            return item;
        }

        public async Task<bool> ExistAsync(K id)
        {
            return await _dataSet.AnyAsync(p => p.Id.Equals(id));
        }
    }
}



