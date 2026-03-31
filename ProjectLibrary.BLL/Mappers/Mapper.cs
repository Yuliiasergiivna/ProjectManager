using ProjectLibrary.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectLibrary.BLL.Mappers
{
    public static class Mapper
    {
        public static BLL.Entities.Employee ToEmployee(this DAL.Entities.Employee employee)
        {
            if (employee is null) throw new ArgumentNullException(nameof(employee));
            var bllEmployee = new BLL.Entities.Employee(
                employee.EmployeeId, 
                employee.FirstName, 
                employee.LastName,
                employee.Hiredate,
                employee.IsProjectManager);
            bllEmployee.Email = employee.Email;
            return bllEmployee;
        }
        public static DAL.Entities.Employee ToDalEmployee(this BLL.Entities.Employee employee)
        {
            if (employee is null) throw new ArgumentNullException(nameof(employee));
            return new DAL.Entities.Employee()
            {
                EmployeeId = employee.EmployeeId,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Hiredate = employee.Hiredate,
                Email = employee.Email,
                IsProjectManager = employee.IsProjectManager
            };
        }
        public static BLL.Entities.Post ToPost(this DAL.Entities.Post post)
        {
            if (post is null) throw new ArgumentNullException(nameof(post));
            return new BLL.Entities.Post(
                post.PostId, 
                post.Subject, 
                post.Content, 
                post.SendDate, 
                post.EmployeeId, 
                post.ProjectId);
        }
        public static DAL.Entities.Post ToDalPost(this BLL.Entities.Post post)
        {
            if (post is null) throw new ArgumentNullException(nameof(post));
            return new DAL.Entities.Post()
            {
                PostId = post.PostId,
                Subject = post.Subject,
                Content = post.Content,
                SendDate = post.SendDate,
                EmployeeId = post.EmployeeId,
                ProjectId = post.ProjectId
            };
        }
        public static BLL.Entities.Project ToProject(this DAL.Entities.Project project)
        {
            if (project is null) throw new ArgumentNullException(nameof(project));
            return new BLL.Entities.Project(
                project.ProjectId, 
                project.Name, 
                project.Description, 
                project.CreationDate,
                project.ProjectManagerId);
        }
        public static DAL.Entities.Project ToDalProject(this BLL.Entities.Project project)
        {
            if (project is null) throw new ArgumentNullException(nameof(project));
            return new DAL.Entities.Project()
            {
                ProjectId = project.ProjectId,
                Name = project.Name,
                Description = project.Description,
                CreationDate = project.CreationDate,
                ProjectManagerId = project.ProjectManagerId
            };
        }
        public static BLL.Entities.TakePart ToTakePart(this DAL.Entities.TakePart takePart)
        {
            if (takePart is null) throw new ArgumentNullException(nameof(takePart));
            return new BLL.Entities.TakePart(
                takePart.EmployeeId, 
                takePart.ProjectId,
                takePart.StartDate,
                takePart.EndDate);
        }
        public static DAL.Entities.TakePart ToDalTakePart(this BLL.Entities.TakePart takePart)
        {
            if (takePart is null) throw new ArgumentNullException(nameof(takePart));
            return new DAL.Entities.TakePart()
            {
                EmployeeId = takePart.EmployeeId,
                ProjectId = takePart.ProjectId,
                StartDate = takePart.StartDate,
                EndDate = takePart.EndDate
            };
        }
        public static BLL.Entities.User ToUser(this DAL.Entities.User user)
        {
            if (user is null) throw new ArgumentNullException(nameof(user));
            return new Entities.User(
                user.UserId, 
                user.Email, 
                user.Password, 
                user.Salt, 
                user.EmployeeId);
        }
        public static DAL.Entities.User ToDalUser(this BLL.Entities.User user)
        {
            if (user is null) throw new ArgumentNullException(nameof(user));
            return new DAL.Entities.User()
            {
                UserId = user.UserId,
                Email = user.Email,
                Password = user.Password,
                Salt = user.Salt,
                EmployeeId = user.EmployeeId
            };
        }
    }
}
