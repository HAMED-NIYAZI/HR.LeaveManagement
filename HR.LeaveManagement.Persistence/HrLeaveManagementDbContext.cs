 using HR.LeaveManagement.Domain.Entity;
using HR.LeaveManagement.Domain.Entity.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Persistence
{
    public class LeaveManagementDbContext : DbContext
    {
        public LeaveManagementDbContext(DbContextOptions<LeaveManagementDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(LeaveManagementDbContext).Assembly);   
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken=default)
        {

            foreach (var entry in ChangeTracker.Entries<BaseDomainEntity>())//چنج ترک ها را نگاه میکند
            {
                entry.Entity.LastModifiedDate = DateTime.Now;         //آخرین اپدیت را ست میکند
                if (entry.State==EntityState.Added)                 //اگر وضعیت ادد بود تاریخ ایجاد را تاریخ جاری میزند
                {
                    entry.Entity.DateCreated = DateTime.Now;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        public DbSet<LeaveType> LeaveTypes { get; set; }
        public DbSet<LeaveRequest> LeaveRequests { get; set; }
        public DbSet<LeaveAllocation> LeaveAllocations { get; set; }
    }
}
