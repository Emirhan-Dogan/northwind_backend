using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NorthwindBackend.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindBackend.Business.Constants
{
    public static class Messages // dil destekli sistemler ile yapılandır.
    {
        // Product
        public static string ProductAdded = "Ürün başarı ile eklendi.";
        public static string ProductDeleted = "Ürün başarı ile silindi.";
        public static string ProductUpdated = "Ürün başarı ile güncelendi.";
        public static string ProductList = "Ürünler başarı ile sunuldu.";
        public static string ProductGet = "Ürün başarı ile sunuldu.";
        
    }
}
