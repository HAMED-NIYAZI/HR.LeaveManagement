using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Persistence.Repositories
{
    public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
    {
        private readonly LeaveManagementDbContext _dbContext;
        public LeaveRequestRepository(LeaveManagementDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task ChangeApprovalStatus(LeaveRequest leaveRequest, bool? approvalStatus)
        {
             leaveRequest.Approved= approvalStatus;
            _dbContext.Entry(leaveRequest).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            //  await Update(leaveRequest);
        }

        public async Task<List<LeaveRequest>> GetLeaveRequeatsWithDetails()
        {
           var leaveRequeatsWithDetails=await _dbContext.Set<LeaveRequest>()
                .Include(q=>q.LeaveType)
                .ToListAsync();
            return leaveRequeatsWithDetails;
        }

        public async Task<LeaveRequest> GetLeaveRequeatWithDetails(int Id)
        {
           var leaveRequest=await _dbContext.LeaveRequests
                .Include(q=>q.LeaveType)
                .FirstOrDefaultAsync(t=>t.Id==Id);
            return leaveRequest;
        }
    }
}
