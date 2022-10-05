using Business.Abstract;
using Business.BusinessRules;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public static class BusinessServiceRegistration
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services) 
        {
            
            services.AddSingleton<IBrandDal, InMemoryBrandDal>(); // 100
            services.AddSingleton<BrandBusinessRules>(); // 101
            services.AddSingleton<IBrandService, BrandManager>(); // 102
            services.AddAutoMapper(assemblies: AppDomain.CurrentDomain.GetAssemblies());

            
            return services;
        }
    }
}
