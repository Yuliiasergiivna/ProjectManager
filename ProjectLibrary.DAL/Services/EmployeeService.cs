using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Microsoft.Data.SqlClient;
using ProjectLibrary.Common.Repositories;
using ProjectLibrary.DAL.Entities;
using ProjectLibrary.DAL.Mappers;

namespace ProjectLibrary.DAL.Services
{
    public class EmployeeService : IEmployeeRepository<Employee>
    {
        private readonly SqlConnection _connection;

        public EmployeeService(SqlConnection connection)
        {
            _connection = connection;
        }
        public IEnumerable<Employee> GetAvailableEmployees()
        {
            using (SqlCommand command = _connection.CreateCommand()) 
            { 
                command.CommandText = "SP_Employee_GetFree";
                command.CommandType = CommandType.StoredProcedure;
                _connection.Open();
                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    while (reader.Read())
                    {
                        yield return reader.ToEmployee();
                    }
                }
                _connection.Close();
            }
        }

        //public Employee GetByEmail(string email)
        //{
        //   using (SqlCommand command = _connection.CreateCommand())
        //    {
        //        command.CommandText = "";
        //        command.CommandType = CommandType.StoredProcedure;
        //        command.Parameters.AddWithValue(nameof(email), email);
        //        _connection.Open();
        //        using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
        //        {
        //            if (reader.Read())
        //            {
        //                return reader.ToEmployee();
        //            }
        //            throw new ArgumentOutOfRangeException(nameof(email), $"No employee found with email {email}");
        //        }
        //        _connection.Close();
        //    }
        //}

        public Employee GetEmployeeById(Guid EmployeeId)
        {
            using (SqlCommand command = _connection.CreateCommand())
            {
                command.CommandText = "SP_Employee_Get_FromEmployeeId";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue(nameof(EmployeeId), EmployeeId);
               if (_connection.State != ConnectionState.Open) _connection.Open();
                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (reader.Read())
                    {
                        return reader.ToEmployee();
                    }
                    throw new ArgumentOutOfRangeException(nameof(EmployeeId), $"No employee found with id {EmployeeId}");
                }
                _connection.Close();
            }
        }

        public IEnumerable<Employee> GetProjectMember(Guid projectId)
        {
            using (SqlCommand command = _connection.CreateCommand())
            {
                command.CommandText = "SP_Employee_Get_FromProjectId";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue(nameof(projectId), projectId);
                if (_connection.State != ConnectionState.Open) _connection.Open();
                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    while (reader.Read())
                    {
                        yield return reader.ToEmployee();
                    }
                }
                _connection.Close();
            }
        }

    }
}
