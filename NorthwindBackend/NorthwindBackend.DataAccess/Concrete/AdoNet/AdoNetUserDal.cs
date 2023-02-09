using Core.Entities.Concrete;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using NorthwindBackend.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindBackend.DataAccess.Concrete.AdoNet
{
    public class AdoNetUserDal : IUserDal
    {
        public AdoNetUserDal()
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

        public void Add(User entity)
        {
            ConnectionControl();

            SqlCommand command = new SqlCommand("INSERT INTO Users VALUES(@FirstName, @LastName, @Email, @Status, @PasswordSalt, @PasswordHash)", _connection);
            command.Parameters.AddWithValue("@FirstName", entity.FirstName);
            command.Parameters.AddWithValue("@LastName", entity.LastName);
            command.Parameters.AddWithValue("@Email", entity.Email);
            command.Parameters.AddWithValue("@Status", entity.Status);
            command.Parameters.AddWithValue("@PasswordSalt", entity.PasswordSalt);
            command.Parameters.AddWithValue("@PasswordHash", entity.PasswordHash);

            command.ExecuteNonQuery();
            _connection.Close();
        }

        public void Delete(User entity)
        {
            ConnectionControl();

            SqlCommand command = new SqlCommand("DELETE FROM Users WHERE Id=@Id", _connection);
            command.Parameters.AddWithValue(@"Id", entity.Id);

            command.ExecuteNonQuery();
            _connection.Close();
        }

        public User Get(Expression<Func<User, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public IList<User> GetAll(Expression<Func<User, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<OperationClaim> GetClaims(User user)
        {
            throw new NotImplementedException();
        }

        public List<User> IsEmailAvailable(string email)
        {
            throw new NotImplementedException();
        }

        public void Update(User entity)
        {
            ConnectionControl();

            SqlCommand command = new SqlCommand(
                "UPDATE Users SET FirstName=@FirstName, LastName=@LastName, Email=@Email, Status=@Status, PasswordSalt=@PasswordSalt, PasswordHash=@PasswordHash WHERE Id=@Id", 
                _connection);
            command.Parameters.AddWithValue(@"Id", entity.Id);
            command.Parameters.AddWithValue("@FirstName", entity.FirstName);
            command.Parameters.AddWithValue("@LastName", entity.LastName);
            command.Parameters.AddWithValue("@Email", entity.Email);
            command.Parameters.AddWithValue("@Status", entity.Status);
            command.Parameters.AddWithValue("@PasswordSalt", entity.PasswordSalt);
            command.Parameters.AddWithValue("@PasswordHash", entity.PasswordHash);

            command.ExecuteNonQuery();
            _connection.Close();
        }
    }
}
