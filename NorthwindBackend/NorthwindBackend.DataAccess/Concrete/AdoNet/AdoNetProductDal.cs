using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using NorthwindBackend.DataAccess.Abstract;
using NorthwindBackend.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindBackend.DataAccess.Concrete.AdoNet
{
    public class AdoNetProductDal : IProductDal
    {
        public AdoNetProductDal()
        {
            ConfigurationManager configurationManager = new ConfigurationManager();
            configurationManager.SetBasePath(Directory.GetCurrentDirectory());
            configurationManager.AddJsonFile("appsettings.json");

            _connection = new SqlConnection(configurationManager.GetConnectionString("SQLServer"));
        }

        private void ConnectionControl()
        {
            if (_connection.State == ConnectionState.Closed)
            {
                _connection.Open();
            }
        }

        private SqlConnection _connection;

        public void Add(Product entity)
        {
            ConnectionControl();

            SqlCommand command = new SqlCommand("INSERT INTO Products VALUES(@SupplierID, @CategoryID, @ProductName, @UnitPrice, @QuantityPerUnit, @UnitsInStock, @UnitsOnOrder, @ReorderLevel, @Discontinued)", _connection);
            command.Parameters.AddWithValue("@SupplierID", entity.SupplierID);
            command.Parameters.AddWithValue("@CategoryID", entity.CategoryID);

            command.Parameters.AddWithValue("@ProductName", entity.ProductID);
            command.Parameters.AddWithValue("@UnitPrice", entity.UnitPrice);
            command.Parameters.AddWithValue("@QuantityPerUnit", entity.QuantityPerUnit);
            command.Parameters.AddWithValue("@UnitsInStock", entity.UnitsInStock);
            command.Parameters.AddWithValue("@UnitsOnOrder", entity.UnitsOnOrder);
            command.Parameters.AddWithValue("@ReorderLevel", entity.ReorderLevel);
            command.Parameters.AddWithValue("@Discontinued", entity.Discontinued);

            command.ExecuteNonQuery();
            _connection.Close();
        }

        public void Delete(Product entity)
        {
            ConnectionControl();

            SqlCommand command = new SqlCommand("DELETE FROM Products WHERE ProductID=@ProductID", _connection);
            command.Parameters.AddWithValue(@"ProductID", entity.ProductID);

            command.ExecuteNonQuery();
            _connection.Close();
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public IList<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void Update(Product entity)
        {
            ConnectionControl();

            SqlCommand command = new SqlCommand(
                "UPDATE Products SET SupplierID=@SupplierID, CategoryID=@CategoryID, ProductName=@ProductName, UnitPrice=@UnitPrice, QuantityPerUnit=@QuantityPerUnit, UnitsInStock=@UnitsInStock, UnitsOnOrder=@UnitsOnOrder, ReorderLevel=@ReorderLevel, Discontinued=@Discontinued WHERE ProductID=@ProductID", _connection);
            command.Parameters.AddWithValue(@"ProductID", entity.ProductID);
            command.Parameters.AddWithValue("@SupplierID", entity.SupplierID);
            command.Parameters.AddWithValue("@CategoryID", entity.CategoryID);

            command.Parameters.AddWithValue("@ProductName", entity.ProductID);
            command.Parameters.AddWithValue("@UnitPrice", entity.UnitPrice);
            command.Parameters.AddWithValue("@QuantityPerUnit", entity.QuantityPerUnit);
            command.Parameters.AddWithValue("@UnitsInStock", entity.UnitsInStock);
            command.Parameters.AddWithValue("@UnitsOnOrder", entity.UnitsOnOrder);
            command.Parameters.AddWithValue("@ReorderLevel", entity.ReorderLevel);
            command.Parameters.AddWithValue("@Discontinued", entity.Discontinued);

            command.ExecuteNonQuery();
            _connection.Close();
        }
    }
}
