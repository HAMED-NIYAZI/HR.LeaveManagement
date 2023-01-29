using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagement.Application.DTOs.LeaveType.Validator
{
    public class UpdateLeaveTypeDtoValidator : AbstractValidator<LeaveTypeDto>
    {
        public UpdateLeaveTypeDtoValidator()
        {
            Include(new IleaveTypeDtoValidator());
            RuleFor(p => p.Id).NotNull().WithMessage("{Property Name} must be present");
        }
    }
}
