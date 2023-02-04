
using Microsoft.Extensions.DependencyInjection;
using NorthwindBackend.Business.Abstract;
using NorthwindBackend.Business.Concrete;
using NorthwindBackend.DataAccess.Abstract;
using NorthwindBackend.DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindBackend.Business.DependencyResolvers.DefaultServicesContainer
{
    public static class ServiceRegistration
    {

        public static void addBusinessServices(this IServiceCollection services)
        {
            // Product
            services.AddSingleton<IProductService, ProductManager>();
        }

        public static void addDataAccessServices(this IServiceCollection services)
        {
            // Product
            services.AddSingleton<IProductDal, EfProductDal>();
        }
    }
}
