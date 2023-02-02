using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Persistence.Repositories
{
    public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
    {
        private readonly LeaveManagementDbContext _dbContext;

        public LeaveAllocationRepository(LeaveManagementDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails()
        {
            var leaveAllocationsWithDetails = await _dbContext.LeaveAllocations
                .Include(t => t.LeaveType)
                .ToListAsync();
            return leaveAllocationsWithDetails;
        }

        public Task<LeaveAllocation> GetLeaveAllocationWithDetails(int Id)
        {
            var leaveAllocationWithDetails = _dbContext.LeaveAllocations
                .Include(t => t.LeaveType)
                .FirstOrDefaultAsync(t => t.Id == Id);
            return leaveAllocationWithDetails;
        }
    }
}
