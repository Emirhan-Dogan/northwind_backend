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
        public static string AddedEntities(string entityType)
        {
            return $"The {entityType} has been unsuccessfull not add.";
        }

        public static string DeletedEntities(string entityType)
        {
            return $"The {entityType} has been unsuccessfull not delete.";
        }

        public static string UpdatedEntities(string entityType)
        {
            return $"The {entityType} has been unsuccessfull not update.";
        }

        public static string ListEntities(string entityType)
        {
            return $"{entityType} not presented unsuccessfull.";
        }

        public static string GetEntities(string entityType)
        {
            return $"{entityType} not presented unsuccessfull.";
        }
        
        // Authentication
        public static string UserNotFound = "User Not Found.";
        public static string PasswordError = "Password Error.";
        public static string UserAlreadyExists = "User is available.";
    }
}
