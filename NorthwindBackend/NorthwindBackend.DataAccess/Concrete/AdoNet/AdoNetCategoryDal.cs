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
    public class AdoNetCategoryDal : ICategoryDal
    {
        public AdoNetCategoryDal()
        {
            ConfigurationManager configurationManager = new ConfigurationManager();
            configurationManager.SetBasePath(Directory.GetCurrentDirectory());
            configurationManager.AddJsonFile("appsettings.json");

            _connection = new SqlConnection(configurationManager.GetConnectionString("SQLServer "));
        }

        private void ConnectionControl()
        {
            if (_connection.State == ConnectionState.Closed)
            {
                _connection.Open();
            }
        }

        private SqlConnection _connection;

        public void Add(Category entity)
        {
            ConnectionControl();

            SqlCommand command = new SqlCommand("INSERT INTO Categories VALUES(@CategoryName, @Description)", _connection);
            command.Parameters.AddWithValue("@CategoryName", entity.CategoryName);
            command.Parameters.AddWithValue("@Description", entity.Description);

            command.ExecuteNonQuery();
            _connection.Close();
        }

        public void Delete(Category entity)
        {
            ConnectionControl();

            SqlCommand command = new SqlCommand("DELETE FROM Categories WHERE CategoryID=@CategoryID", _connection);
            command.Parameters.AddWithValue(@"CategoryID", entity.CategoryID);

            command.ExecuteNonQuery();
            _connection.Close();
        }

        public Category Get(Expression<Func<Category, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public IList<Category> GetAll(Expression<Func<Category, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void Update(Category entity)
        {
            ConnectionControl();

            SqlCommand command = new SqlCommand("UPDATE Categories SET Description=@Description, CategoryName=@CategoryName WHERE CategoryID=@CategoryID", _connection);
            command.Parameters.AddWithValue(@"CategoryID", entity.CategoryID);
            command.Parameters.AddWithValue("@CategoryName", entity.CategoryName);
            command.Parameters.AddWithValue("@Description", entity.Description);

            command.ExecuteNonQuery();
            _connection.Close();
        }
    }
}
