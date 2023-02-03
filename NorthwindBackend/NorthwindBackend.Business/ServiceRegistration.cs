
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

namespace NorthwindBackend.Business
{
    public static class ServiceRegistration
    {

        public static void addBusinessServices(this IServiceCollection services)
        {
            services.AddSingleton<IProductService, ProductManager>();
            services.AddSingleton<IProductDal, EfProductDal>();
        }
    }
}
