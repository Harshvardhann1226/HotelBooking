using HotelBooking.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Repository.Extension
{
    public interface IUnitofWork:IDisposable
    {
        IGenericRepository<T> Repository<T>() where T : class;
        Task<int> SaveAsync();
    }
}
