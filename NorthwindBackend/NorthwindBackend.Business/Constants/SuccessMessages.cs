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
        public static string AddedEntities(string entityType)
        {
            return $"The {entityType} has been successfully added.";
        }

        public static string DeletedEntities(string entityType)
        {
            return $"The {entityType} has been successfully deleted.";
        }

        public static string UpdatedEntities(string entityType)
        {
            return $"The {entityType} has been successfully updated.";
        }

        public static string ListEntities(string entityType)
        {
            return $"{entityType} presented successfully.";
        }

        public static string GetEntities(string entityType)
        {
            return $"{entityType} presented successfully.";
        }

        // Authentication
        public static string SuccessfulLogin = "Successful User Login";
        public static string UserIsNotAvailable = "User is not available";
        public static string UserRegistered = "User Registered.";
        public static string CreateAccessToken = "Creating access token successful";
    }
}
