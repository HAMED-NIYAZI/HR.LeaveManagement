using HR.LeaveManagement.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Persistence.Contracts
{
    public interface ILeaveRequestRepository:IGenericRepository<LeaveRequest>
    {
        Task<LeaveRequest> GetLeaveRequeatWithDetails(int Id);
        Task<List<LeaveRequest>> GetLeaveRequeatsWithDetails();
    }
}
