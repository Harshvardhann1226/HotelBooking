using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Repository.Extension
{
    public  static class ServiceRepoRegisteration
    {
        public static void AddRepositoryServices(this IServiceCollection services)
        {
            // Register UnitOfWork
            services.AddScoped<IUnitofWork, UnitofWork>();

            // (Optional) Register Generic Repository if needed directly
            //services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        }
    }
}
