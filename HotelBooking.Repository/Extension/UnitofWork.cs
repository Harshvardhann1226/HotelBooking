using HotelBooking.Domain.Entity;
using HotelBooking.Repository.DataContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Repository.Extension
{
    public class UnitofWork : IUnitofWork
    {
        private readonly ApplicationdbContext _dbcontext;
        private readonly Dictionary<Type, object> _repositories = new();
        public UnitofWork(ApplicationdbContext context)
        {
                _dbcontext = context;
        }
       

        public void Dispose()
        {
            _dbcontext.Dispose();
        }

        public IGenericRepository<T> Repository<T>() where T : class
        {
            if (!_repositories.ContainsKey(typeof(T)))
            {
                var repo = new GenericRepository<T>(_dbcontext);
                _repositories[typeof(T)] = repo;
            }
            return (IGenericRepository<T>)_repositories[typeof(T)]; ;
        }

        public async Task<int> SaveAsync()
        {
            return await _dbcontext.SaveChangesAsync();
        }
    }
}
