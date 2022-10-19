using Business.Abstract;
using Business.BusinessRules;
using Business.Concrete;
using Core.Business.Mailing;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
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
            
            services.AddSingleton<IBrandDal, EfBrandDal>(); // 100
            services.AddSingleton<BrandBusinessRules>(); // 101
            services.AddSingleton<IBrandService, BrandManager>(); // 102
            services.AddAutoMapper(assemblies: AppDomain.CurrentDomain.GetAssemblies());

            services.AddSingleton<ICarTypeDal, EfCarTypeDal>();
            services.AddSingleton<CarTypeBusinessRules>();
            services.AddSingleton<ICarTypeService,CarTypeManager>();

            services.AddSingleton<IColorDal, EfColorDal>();
            services.AddSingleton<ColorBusinessRules>();
            services.AddSingleton<IColorService, ColorManager>();

            services.AddSingleton<IFuelDal, EfFuelDal>();
            services.AddSingleton<FuelBusinessRules>();
            services.AddSingleton<IFuelService, FuelManager>();

            services.AddSingleton<IModelDal, EfModelDal>();
            services.AddSingleton<ModelBusinessRules>();
            services.AddSingleton<IModelService, ModelManager>();

            services.AddSingleton<ICarStateDal, EfCarStateDal>();
            services.AddSingleton<CarStateBusinessRules>();
            services.AddSingleton<ICarStateService, CarStateManager>();

            services.AddSingleton<ICarDal, EfCarDal>();
            services.AddSingleton<CarBusinessRules>();
            services.AddSingleton<ICarService, CarManager>();

            services.AddSingleton<IUserDal, EfUserDal>();
            services.AddSingleton<UserBusinessRules>();
            services.AddSingleton<IUserService, UserManager>();

            services.AddSingleton<IRentalDal, EfRentalDal>();
            //services.AddSingleton<RentalBusinessRules>();
            services.AddSingleton<IRentalService, RentalManager>();

            services.AddSingleton<ICustomerDal, EfCustomerDal>();
            //services.AddSingleton<CustomerBusinessRules>();
            services.AddSingleton<ICustomerService, CustomerManager>();

            services.AddSingleton<IMailService, MailKitMailService>();
            return services;
        }
    }
}
