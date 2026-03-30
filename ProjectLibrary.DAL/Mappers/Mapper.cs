using ProjectLibrary.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.CompilerServices;
using System.Text;

namespace ProjectLibrary.DAL.Mappers
{
    internal static class Mapper
    {
        public static Employee ToEmployee(this IDataRecord record)
        {
            if (record is null) throw new ArgumentNullException(nameof(record));
            return new Employee()
            {
                EmployeeId = (Guid)record[nameof(Employee.EmployeeId)],
                FirstName = (string)record[nameof(Employee.FirstName)],
                LastName = (string)record[nameof(Employee.LastName)],
                Hiredate = (DateTime)record[nameof(Employee.Hiredate)],
                Email = (record[nameof(Employee.Email)] is DBNull)? null : (string)record[nameof(Employee.Email)],
                IsProjectManager = (bool)record[nameof(Employee.IsProjectManager)],
            };
        }

        public static Project ToProject(this IDataRecord record)
        {
            if (record is null) throw new ArgumentNullException(nameof(record));
            return new Project()
            {
                ProjectId = (Guid)record[nameof(Project.ProjectId)],
                Name = (string)record[nameof(Project.Name)],
                Description = (string)record[nameof(Project.Description)],
                CreationDate = (DateTime)record[nameof(Project.CreationDate)],
                ProjectManagerId = (Guid)record[nameof(Project.ProjectManagerId)],
            };
        }

        public static Post ToPost(this IDataRecord record)
        {
            if (record is null) throw new ArgumentNullException(nameof(record));
            return new Post()
            {
                PostId = (Guid)record[nameof(Post.PostId)],
                Subject = (string)record[nameof(Post.Subject)],
                Content = (string)record[nameof(Post.Content)],
                SendDate = (DateTime)record[nameof(Post.SendDate)],
                EmployeeId = (Guid)record[nameof(Post.EmployeeId)],
                ProjectId = (Guid)record[nameof(Post.ProjectId)],
            };
        }
        public static TakePart ToTakePart(this IDataRecord record)
        {
            if (record is null) throw new ArgumentNullException(nameof(record));
            return new TakePart()
            {
                EmployeeId = (Guid)record[nameof(TakePart.EmployeeId)],
                ProjectId = (Guid)record[nameof(TakePart.ProjectId)],
                StartDate = (DateTime)record[nameof(TakePart.StartDate)],
                EndDate = (record[nameof(TakePart.EndDate)] is DBNull) ? null : (DateTime?)record[nameof(TakePart.EndDate)],
            };
        }
        public static User ToUser(this IDataRecord record)
        {
            if (record is null) throw new ArgumentNullException(nameof(record));
            return new User()
            {
                UserId = (Guid)record[nameof(User.UserId)],
                Email = (string)record[nameof(User.Email)],
                Password = (byte[])record[nameof(User.Password)],
                Salt = (Guid)record[nameof(User.Salt)],
                EmployeeId = (Guid)record[nameof(User.EmployeeId)],
            };
        }
    }
}
