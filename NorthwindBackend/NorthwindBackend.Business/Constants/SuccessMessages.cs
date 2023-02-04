using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NorthwindBackend.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindBackend.Business.Constants
{
    public static class SuccessMessages // dil destekli sistemler ile yapılandır.
    {
        // Product
        public static string ProductAdded = "The Product has been successfully added.";
        public static string ProductDeleted = "The Product has been successfully deleted.";
        public static string ProductUpdated = "The Product has been successfully updated.";
        public static string ProductList = "Product presented successfully.";
        public static string ProductGet = "Product presented successfully.";

        // Category
        public static string CategoryAdded = "The Category has been successfully added.";
        public static string CategoryDeleted = "The Category has been successfully deleted.";
        public static string CategoryUpdated = "The Category has been successfully updated.";
        public static string CategoryList = "Category presented successfully.";
        public static string CategoryGet = "Category presented successfully.";

        // Customer
        public static string CustomerAdded = "The Customer has been successfully added.";
        public static string CustomerDeleted = "The Customer has been successfully deleted.";
        public static string CustomerUpdated = "The Customer has been successfully updated.";
        public static string CustomerList = "Customer presented successfully.";
        public static string CustomerGet = "Customer presented successfully.";

        // Employee
        public static string EmployeeAdded = "The Employee has been successfully added.";
        public static string EmployeeDeleted = "The Employee has been successfully deleted.";
        public static string EmployeeUpdated = "The Employee has been successfully updated.";
        public static string EmployeeList = "Employee presented successfully.";
        public static string EmployeeGet = "Employee presented successfully.";

        // OperationClaim
        public static string OperationClaimAdded = "The OperationClaim has been successfully added.";
        public static string OperationClaimDeleted = "The OperationClaim has been successfully deleted.";
        public static string OperationClaimUpdated = "The OperationClaim has been successfully updated.";
        public static string OperationClaimList = "OperationClaim presented successfully.";
        public static string OperationClaimGet = "OperationClaim presented successfully.";

        // Order
        public static string OrderAdded = "The Order has been successfully added.";
        public static string OrderDeleted = "The Order has been successfully deleted.";
        public static string OrderUpdated = "The Order has been successfully updated.";
        public static string OrderList = "Order presented successfully.";
        public static string OrderGet = "Order presented successfully.";

        // OrderDetail
        public static string OrderDetailAdded = "The OrderDetail has been successfully added.";
        public static string OrderDetailDeleted = "The OrderDetail has been successfully deleted.";
        public static string OrderDetailUpdated = "The OrderDetail has been successfully updated.";
        public static string OrderDetailList = "OrderDetail presented successfully.";
        public static string OrderDetailGet = "OrderDetail presented successfully.";

        // Region
        public static string RegionAdded = "The Region has been successfully added.";
        public static string RegionDeleted = "The Region has been successfully deleted.";
        public static string RegionUpdated = "The Region has been successfully updated.";
        public static string RegionList = "Region presented successfully.";
        public static string RegionGet = "Region presented successfully.";

        // Shipper
        public static string ShipperAdded = "The Shipper has been successfully added.";
        public static string ShipperDeleted = "The Shipper has been successfully deleted.";
        public static string ShipperUpdated = "The Shipper has been successfully updated.";
        public static string ShipperList = "Shipper presented successfully.";
        public static string ShipperGet = "Shipper presented successfully.";

        // Supplier
        public static string SupplierAdded = "The Supplier has been successfully added.";
        public static string SupplierDeleted = "The Supplier has been successfully deleted.";
        public static string SupplierUpdated = "The Supplier has been successfully updated.";
        public static string SupplierList = "Supplier presented successfully.";
        public static string SupplierGet = "Supplier presented successfully.";

        // Territory
        public static string TerritoryAdded = "The Territory has been successfully added.";
        public static string TerritoryDeleted = "The Territory has been successfully deleted.";
        public static string TerritoryUpdated = "The Territory has been successfully updated.";
        public static string TerritoryList = "Territory presented successfully.";
        public static string TerritoryGet = "Territory presented successfully.";

        // User
        public static string UserAdded = "The User has been successfully added.";
        public static string UserDeleted = "The User has been successfully deleted.";
        public static string UserUpdated = "The User has been successfully updated.";
        public static string UserList = "User presented successfully.";
        public static string UserGet = "User presented successfully.";

        // UserOperationClaim
        public static string UserOperationClaimAdded = "The UserOperationClaim has been successfully added.";
        public static string UserOperationClaimDeleted = "The UserOperationClaim has been successfully deleted.";
        public static string UserOperationClaimUpdated = "The UserOperationClaim has been successfully updated.";
        public static string UserOperationClaimList = "UserOperationClaim presented successfully.";
        public static string UserOperationClaimGet = "UserOperationClaim presented successfully.";

    }
}
