using Core.Entities.Concrete;
using Core.Utilities.Result;
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
    public class AdoNetOperationClaimDal : IOperationClaimDal
    {
        public AdoNetOperationClaimDal()
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

        public void Add(OperationClaim entity)
        {
            ConnectionControl();

            SqlCommand command = new SqlCommand("INSERT INTO OperationClaims VALUES(@Name)", _connection);
            command.Parameters.AddWithValue("@Name", entity.Name);

            command.ExecuteNonQuery();
            _connection.Close();
        }

        public void Delete(OperationClaim entity)
        {
            ConnectionControl();

            SqlCommand command = new SqlCommand("DELETE FROM OperationClaims WHERE Id=@Id", _connection);
            command.Parameters.AddWithValue(@"Id", entity.Id);

            command.ExecuteNonQuery();
            _connection.Close();
        }

        public OperationClaim Get(Expression<Func<OperationClaim, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public IList<OperationClaim> GetAll(Expression<Func<OperationClaim, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void Update(OperationClaim entity)
        {
            ConnectionControl();

            SqlCommand command = new SqlCommand("UPDATE OperationClaims SET Name=@Name WHERE Id=@Id", _connection);
            command.Parameters.AddWithValue(@"Id", entity.Id);
            command.Parameters.AddWithValue("@UserId", entity.Name);

            command.ExecuteNonQuery();
            _connection.Close();
        }
    }
}
