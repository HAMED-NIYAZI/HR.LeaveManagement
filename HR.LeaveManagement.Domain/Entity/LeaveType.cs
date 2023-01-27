using HR.LeaveManagement.Domain.Entity.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagement.Domain.Entity
{
    public class LeaveType: BaseDomainEntity
    {
         public string Name { get; set; }
        public int DefaultDays { get; set; }
     }
}
