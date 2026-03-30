using Microsoft.Data.SqlClient;
using ProjectLibrary.Common.Repositories;
using ProjectLibrary.DAL.Entities;
using ProjectLibrary.DAL.Mappers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ProjectLibrary.DAL.Services
{
    public class UserService : IUserRepository<User>
    {
        private readonly SqlConnection _connection;

        public UserService(SqlConnection connection)
        {
            _connection = connection;
        }

        public Guid Add(User user)
        {
            using (SqlCommand command = _connection.CreateCommand())
            {
                command.CommandText ="SP_User_Insert";
                command.CommandType=CommandType.StoredProcedure;
                command.Parameters.AddWithValue(nameof(user.Email), user.Email);
                command.Parameters.AddWithValue(nameof(user.Password), user.Password);
                command.Parameters.AddWithValue(nameof(user.EmployeeId), user.EmployeeId);
                if (_connection.State != ConnectionState.Open) _connection.Open();
                return (Guid)command.ExecuteScalar();
            }
        }

        public Guid? CheckPassword(string email, string password)
        {
            using (SqlCommand command = _connection.CreateCommand())
            {
                command.CommandText = "SP_User_CheckPassword";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue(nameof(email), email);
                command.Parameters.AddWithValue(nameof(password), password);
                if (_connection.State != ConnectionState.Open) _connection.Open();
                    var result = command.ExecuteScalar();
                return (result is DBNull) ? null : (Guid?)result;
         
                //_connection.Close();
            }
        }

        public bool EmailExists(string email)
        {
            return false;
        }

        public User GetFromEmployee(Guid employeeId)
        {
           using (SqlCommand command = _connection.CreateCommand())
            {
                command.CommandText = "SP_User_Get_FromEmployeeId";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue(nameof(employeeId), employeeId);
                if (_connection.State != ConnectionState.Open) _connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return  reader.ToUser();
                    }
                    return null;
                }
            }
        }
    }
}
