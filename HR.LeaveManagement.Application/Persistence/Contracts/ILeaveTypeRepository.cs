using HR.LeaveManagement.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagement.Application.Persistence.Contracts
{
    public interface ILeaveTypeRepository:IGenericRepository<LeaveType>
    {
    }
}
