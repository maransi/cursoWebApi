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
            try
            {
                var result = await _dataSet.SingleOrDefaultAsync( p => p.Id.Equals(id));

                if (result == null)
                    return false;

                _dataSet.Remove(result);

                await _context.SaveChangesAsync();

                return true;
            }
            catch( Exception ex)
            {
                throw ex;
            }
        }

        public async Task<T> InsertAsync(T item)
        {
            try
            {
                item.CreatedAt = DateTime.UtcNow;

                _dataSet.Add(item);

                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {

                throw ex;
            }

            return item;

        }

        public async Task<IEnumerable<T>> SelectAsync()
        {
            try
            {
                return await _dataSet.ToListAsync();
            }
            catch (Exception ex)
            {
                
                throw ex;
            }

        }

        public async Task<T> SelectAsync(K id)
        {
            try
            {
                return await _dataSet.SingleOrDefaultAsync( p=> p.Id.Equals(id));
            }catch( Exception ex )
            {
                throw ex;
            }

        }

        public async Task<T> UpdateAsync(T item)
        {
            try
            {
                var result = await _dataSet.SingleOrDefaultAsync(p => p.Id.Equals(item.Id));

                if (result == null)
                    return null;

                item.UpdateAt = DateTime.UtcNow;
                item.CreatedAt = result.CreatedAt;

                _context.Entry(result).CurrentValues.SetValues(item);

                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return item;
        }

        public  async Task<bool> ExistAsync( K id){
            return await _dataSet.AnyAsync( p => p.Id.Equals(id));
        }
    }
}


