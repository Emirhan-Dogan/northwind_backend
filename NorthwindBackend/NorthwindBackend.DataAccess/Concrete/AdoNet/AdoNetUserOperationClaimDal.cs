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
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace NorthwindBackend.DataAccess.Concrete.AdoNet
{
    public class AdoNetUserOperationClaimDal //: IUserOperationClaimDal
    {
        public AdoNetUserOperationClaimDal()
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

        public void Add(UserOperationClaim entity)
        {
            ConnectionControl();

            SqlCommand command = new SqlCommand("INSERT INTO UserOperationClaims VALUES(@UserId, @OperationClaimId)", _connection);
            command.Parameters.AddWithValue("@UserId", entity.UserId);
            command.Parameters.AddWithValue("@OperationClaimId", entity.OperationClaimId);

            command.ExecuteNonQuery();
            _connection.Close();
        }

        public void Delete(UserOperationClaim entity)
        {
            ConnectionControl();

            SqlCommand command = new SqlCommand("DELETE FROM UserOperationClaims WHERE Id=@Id", _connection);
            command.Parameters.AddWithValue(@"Id", entity.Id);

            command.ExecuteNonQuery();
            _connection.Close();
        }

        public UserOperationClaim Get(Expression<Func<List<UserOperationClaim>, List<UserOperationClaim>>> filter)
        {
            ConnectionControl();

            SqlCommand command = new SqlCommand("SELECT * FROM UserOperationClaims", _connection);
            List<UserOperationClaim> claims = new List<UserOperationClaim>();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                UserOperationClaim userOperationClaim = new UserOperationClaim()
                {
                    Id = (int)reader["Id"],
                    UserId = (int)reader["UserId"],
                    OperationClaimId = (int)reader["OperationClaimId"]
                };
                claims.Add(userOperationClaim);
            }

            Func<List<UserOperationClaim>, List<UserOperationClaim>> filterCompile = filter.Compile();
            List<UserOperationClaim> filterClaims = filterCompile(claims);

            reader.Close();
            _connection.Close();

            return filterClaims == null
                    ? new UserOperationClaim()
                    : filterClaims[0];
        }

        public IList<UserOperationClaim> GetAll(Expression<Func<List<UserOperationClaim>, List<UserOperationClaim>>> filter = null)
        {
            ConnectionControl();

            SqlCommand command = new SqlCommand("SELECT * FROM UserOperationClaims", _connection);
            List<UserOperationClaim> claims = new List<UserOperationClaim>();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                UserOperationClaim userOperationClaim = new UserOperationClaim()
                {
                    Id = (int)reader["Id"],
                    UserId = (int)reader["UserId"],
                    OperationClaimId = (int)reader["OperationClaimId"]
                };
                claims.Add(userOperationClaim);
            }

            reader.Close();
            _connection.Close();

            if (filter != null)
            {
                Func<List<UserOperationClaim>, List<UserOperationClaim>> filterCompile = filter.Compile();
                return filterCompile(claims);
            }
            return claims;
        }

        public void Update(UserOperationClaim entity)
        {
            ConnectionControl();

            SqlCommand command = new SqlCommand("UPDATE UserOperationClaims SET UserId=@UserId, OperationClaimId=@OperationClaimId WHERE Id=@Id", _connection);
            command.Parameters.AddWithValue(@"Id", entity.Id);
            command.Parameters.AddWithValue("@UserId", entity.UserId);
            command.Parameters.AddWithValue("@OperationClaimId", entity.OperationClaimId);

            command.ExecuteNonQuery();
            _connection.Close();
        }
    }
}
