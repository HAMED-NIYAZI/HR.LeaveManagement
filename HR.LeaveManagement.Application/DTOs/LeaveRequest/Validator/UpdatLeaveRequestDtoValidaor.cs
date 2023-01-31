using FluentValidation;
using HR.LeaveManagement.Application.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagement.Application.DTOs.LeaveRequest.Validator
{
    public class UpdatLeaveRequestDtoValidaor : AbstractValidator<UpdateLeaveRequestDto>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public UpdatLeaveRequestDtoValidaor(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository= leaveTypeRepository;
            Include(new ILeaveRequestDtoValidaor(_leaveTypeRepository));

            RuleFor(p => p.Id).NotNull().WithMessage("{PropertyName} must be present.");
        }
    }
}
