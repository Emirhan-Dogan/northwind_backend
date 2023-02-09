 using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindBackend.Business.Constants
{
    public static class ErrorMesages // Dil destekli sistemler ile yapılandırılabilir...
    {
        // Product
        public static string ProductAdded = "The Product has been unsuccessfull not add.";
        public static string ProductDeleted = "The Product has been successfull not delete.";
        public static string ProductUpdated = "The Product has been successfull not update.";
        public static string ProductList = "Product not presented unsuccessfull.";
        public static string ProductGet = "Product not presented unsuccessfull.";

        // Category
        public static string CategoryAdded = "The Category has been unsuccessfull not add.";
        public static string CategoryDeleted = "The Category has been unsuccessfull not delete.";
        public static string CategoryUpdated = "The Category has been unsuccessfull not update.";
        public static string CategoryList = "Category not presented unsuccessfull.";
        public static string CategoryGet = "Category not presented unsuccessfull.";

        // OperationClaim
        public static string OperationClaimAdded = "The OperationClaim has been unsuccessfull not add.";
        public static string OperationClaimDeleted = "The OperationClaim has been unsuccessfull not delete.";
        public static string OperationClaimUpdated = "The OperationClaim has been unsuccessfull not update.";
        public static string OperationClaimList = "OperationClaim not presented unsuccessfull.";
        public static string OperationClaimGet = "OperationClaim not presented unsuccessfull.";

        // User
        public static string UserAdded = "The User has been unsuccessfull not add.";
        public static string UserDeleted = "The User has been unsuccessfull not delete.";
        public static string UserUpdated = "The User has been unsuccessfull not update.";
        public static string UserList = "User not presented unsuccessfull.";
        public static string UserGet = "User not presented unsuccessfull.";

        // UserOperationClaim
        public static string UserOperationClaimAdded = "The UserOperationClaim has been unsuccessfull not add.";
        public static string UserOperationClaimDeleted = "The UserOperationClaim has been unsuccessfull not delete.";
        public static string UserOperationClaimUpdated = "The UserOperationClaim has been unsuccessfull not update.";
        public static string UserOperationClaimList = "UserOperationClaim not presented unsuccessfull.";
        public static string UserOperationClaimGet = "UserOperationClaim not presented unsuccessfull.";

        // Authentication
        public static string UserNotFound = "User Not Found.";
        public static string PasswordError = "Password Error.";
        public static string UserAlreadyExists = "User is available.";
    }
}
