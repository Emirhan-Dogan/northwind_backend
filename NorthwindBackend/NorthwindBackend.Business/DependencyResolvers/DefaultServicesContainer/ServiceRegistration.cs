
using Core.Utilities.Security.JWT;
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
        public static void AddJWTServicess(this IServiceCollection services)
        {
            services.AddSingleton<IAuthService, AuthManager>();
            services.AddSingleton<ITokenHelper, JwtHelper>();
            services.AddSingleton<IUserService, UserManager>();
        }

        public static void AddBusinessServices(this IServiceCollection services)
        {
            // Product
            services.AddSingleton<IProductService, ProductManager>();

            // Category
            services.AddSingleton<ICategoryService, CategoryManager>();

        }

        public static void AddDataAccessEntityFrameworkCoreServicess(this IServiceCollection services)
        {
            // Product
            services.AddSingleton<IProductDal, EfProductDal>();

            // Category
            services.AddSingleton<ICategoryDal, EfCategoryDal>();

            // User
            services.AddSingleton<IUserDal, EfUserDal>();
        }

        public static void AddDataAccessAdoNetServicess(this IServiceCollection services)
        {

        }
    }
}
