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
    public class ProjectService : IProjectRepository<Project>
    {
        private readonly SqlConnection _connection;

        public ProjectService(SqlConnection connection)
        {
            _connection = connection;
        }

        public void AddMember(Guid projectId, Guid employeeId)
        {
            using (SqlCommand command = _connection.CreateCommand())
            {
                command.CommandText = "SP_TakePart_Insert";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue(nameof(projectId), projectId);
                command.Parameters.AddWithValue(nameof(employeeId), employeeId);
                if (_connection.State != ConnectionState.Open) _connection.Open();
                command.ExecuteNonQuery();
            }
        }
        public void RemoveMember(Guid projectId, Guid employeeId)
        {
            using (SqlCommand command = _connection.CreateCommand())
            {
                command.CommandText = "SP_TakePart_SetEnd";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue(nameof(projectId), projectId);
                command.Parameters.AddWithValue(nameof(employeeId), employeeId);
                if (_connection.State != ConnectionState.Open) _connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void AddProject(Project project)
        {
            using (SqlCommand command = _connection.CreateCommand())
            {
                command.CommandText = "SP_Project_Insert";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue(nameof(project.Name), project.Name);
                command.Parameters.AddWithValue(nameof(project.Description), project.Description);
                command.Parameters.AddWithValue(nameof(project.CreationDate), project.CreationDate);
                command.Parameters.AddWithValue(nameof(project.ProjectManagerId), project.ProjectManagerId);
                if (_connection.State != ConnectionState.Open) _connection.Open();
                project.ProjectId = (Guid)command.ExecuteScalar();
            }
        }

        public Project GetProjectById(Guid ProjectId)
        {
           using (SqlCommand command = _connection.CreateCommand())
            {
                command.CommandText = "SP_Project_Get_FromProjectId";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue(nameof(ProjectId), ProjectId);
                _connection.Open();
                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (reader.Read())
                    {
                        return reader.ToProject();
                    }
                    throw new ArgumentOutOfRangeException();
                }
                _connection.Close();
            }
        }

        public IEnumerable<Project> GetProjectsByEmployeeId(Guid employeeId)
        {
            List<Project> projects = new List<Project>();
            using (SqlCommand command = _connection.CreateCommand())
            {
                command.CommandText = "SP_Project_Get_FromEmployeeId";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue(nameof(employeeId), employeeId);
                if (_connection.State != ConnectionState.Open) _connection.Open();
                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    while (reader.Read())
                    {
                        projects.Add( reader.ToProject());
                    }
                }
               return projects;
            }
        }

        public IEnumerable<Project> GetProjectsByManagerId(Guid managerId)
        {
            List<Project> projects = new List<Project>();
            using (SqlCommand command = _connection.CreateCommand())
            {
                command.CommandText = "SP_Project_Get_FromProjectManagerId";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue(nameof(managerId), managerId);
                if (_connection.State != ConnectionState.Open) _connection.Open();
                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    while (reader.Read())
                    {
                        projects.Add (reader.ToProject());
                    }
                }
                return projects;
            }
        }


        public void UpdateProject(Project project)
        {
            using (SqlCommand command = _connection.CreateCommand())
            {
                command.CommandText = "SP_Project_Update";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue(nameof(project.ProjectId), project.ProjectId);
                command.Parameters.AddWithValue(nameof(project.Name), project.Name);
                command.Parameters.AddWithValue(nameof(project.Description), project.Description);
                command.Parameters.AddWithValue(nameof(project.CreationDate), project.CreationDate);
                command.Parameters.AddWithValue(nameof(project.ProjectManagerId), project.ProjectManagerId);
                _connection.Open();
                command.ExecuteNonQuery();
                _connection.Close();
            }
        }
    }
}
