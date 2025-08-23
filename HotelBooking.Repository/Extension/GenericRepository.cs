using HotelBooking.Repository.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Repository.Extension
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationdbContext _dbcontext;
        private readonly DbSet<T> _table;

        public GenericRepository(ApplicationdbContext context)
        {
            _dbcontext = context;

            _table = context.Set<T>();
        }

        public async Task DeleteAsync(object id)
        {
            T existing = await _table.FindAsync(id);
            if (existing == null)
                throw new Exception("Entity not found");

            _table.Remove(existing);
        }

        public async  Task<IEnumerable<T>> GetAllAsync()
        {
            return await _table.ToListAsync();
        }

        public async  Task<T> GetById(object id)
        {
            return await _table.FindAsync(id);
        }

        public async Task InsertAsync(T obj)
        {
           await  _table.AddAsync(obj);
            

        }

       

        public async Task UpdateAsync(T obj)
        {
             _table.Update(obj);

         
        }
    }
}
