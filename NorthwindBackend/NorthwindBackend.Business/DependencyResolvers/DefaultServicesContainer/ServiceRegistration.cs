﻿
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

            // Category
            services.AddSingleton<ICategoryService, CategoryManager>();

            // Customer
            services.AddSingleton<ICustomerService, CustomerManager>();

            // Employee
            services.AddSingleton<IEmployeeService, EmployeeManager>();

            // OperationCalim
            services.AddSingleton<IOperationClaimService, OperationClaimManager>();

            // Order
            services.AddSingleton<IOrderService, OrderManager>();

            // OrderDetail
            services.AddSingleton<IOrderDetailService, OrderDetailManager>();

            // Region
            services.AddSingleton<IRegionService, RegionManager>();

            // Shipper
            services.AddSingleton<IShipperService, ShipperManager>();

            // Supplier
            services.AddSingleton<ISupplierService, SupplierManager>();

            // Territory
            services.AddSingleton<ITerritoryService, TerritoryManager>();

            // User
            services.AddSingleton<IUserService, UserManager>();

            // UserOperationclaim
            services.AddSingleton<IUserOperationClaimService, UserOperationClaimManager>();
        }

        public static void addDataAccessServices(this IServiceCollection services)
        {
            // Product
            services.AddSingleton<IProductDal, EfProductDal>();

            // Category
            services.AddSingleton<ICategoryDal, EfCategoryDal>();

            // Customer
            services.AddSingleton<ICustomerDal, EfCustomerDal>();

            // Employee
            services.AddSingleton<IEmployeeDal, EfEmployeeDal>();

            // OperationCalim
            services.AddSingleton<IOperationClaimDal, EfOperationClaimDal>();

            // Order
            services.AddSingleton<IOrderDal, EfOrderDal>();

            // OrderDetail
            services.AddSingleton<IOrderDetailDal, EfOrderDetailDal>();

            // Region
            services.AddSingleton<IRegionDal, EfRegionDal>();

            // Shipper
            services.AddSingleton<IShipperDal, EfShipperDal>();

            // Supplier
            services.AddSingleton<ISupplierDal, EfSupplierDal>();

            // Territory
            services.AddSingleton<ITerritoryDal, EfTerritoryDal>();

            // User
            services.AddSingleton<IUserDal, EfUserDal>();

            // UserOperationclaim
            services.AddSingleton<IUserOperationClaimDal, EfUserOperationClaimDal>();
        }
    }
}
