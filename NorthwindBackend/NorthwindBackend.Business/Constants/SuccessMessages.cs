using Core.Entities.Concrete;
using Core.Utilities.Security.JWT;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NorthwindBackend.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindBackend.Business.Constants
{
    public static class SuccessMessages // Dil destekli sistemler ile yapılandırılabilir...
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

        // OperationClaim
        public static string OperationClaimAdded = "The OperationClaim has been successfully added.";
        public static string OperationClaimDeleted = "The OperationClaim has been successfully deleted.";
        public static string OperationClaimUpdated = "The OperationClaim has been successfully updated.";
        public static string OperationClaimList = "OperationClaim presented successfully.";
        public static string OperationClaimGet = "OperationClaim presented successfully.";

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

        // Authentication
        public static string SuccessfulLogin = "Successful User Login";
        public static string UserIsNotAvailable = "User is not available";
        public static string UserRegistered = "User Registered.";
        public static string CreateAccessToken = "Creating access token successful";
    }
}
