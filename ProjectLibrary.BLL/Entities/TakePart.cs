using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectLibrary.BLL.Entities
{
    public class TakePart
    {
        public Guid EmployeeId { get; private set; }
        public Guid ProjectId { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime? EndDate { get; private set; }
        public TakePart(Guid employeeId, Guid projectId, DateTime startDate, DateTime? endDate )
        {
            EmployeeId = employeeId;
            ProjectId = projectId;
            StartDate = startDate;
            EndDate = endDate;
        }

        public TakePart(Guid employeeId, Guid projectId)
        {
            EmployeeId = employeeId;
            ProjectId = projectId;
        }
    }
}
