using FluentValidation;
using HR.LeaveManagement.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagement.Application.DTOs.LeaveRequest.Validator
{
    public class CreateLeaveRequestDtoValidaor : AbstractValidator<CreateLeaveRequestDto>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public CreateLeaveRequestDtoValidaor(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository= leaveTypeRepository;
            Include(new ILeaveRequestDtoValidaor(_leaveTypeRepository));

        }
    }
}
