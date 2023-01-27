using AutoMapper;
using FluentValidation;
using HR.LeaveManagement.Application.DTOs.LeaveType.Validator;
using HR.LeaveManagement.Application.Features.LeaveTypes.Requests.Commands;
using HR.LeaveManagement.Application.Persistence.Contracts;
using HR.LeaveManagement.Domain.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Handlers.Commands
{
    public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, int>
    {
        private readonly ILeaveTypeRepository _leaveRequestRepository;
        private readonly IMapper _mapper;
        public CreateLeaveTypeCommandHandler(ILeaveTypeRepository leaveRequestRepository,
               IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            //validate
            var validater = new CreateLeaveTypeDtoValidator();
            var validationResult = await validater.ValidateAsync(request.LeaveTypeDto);

            if (validationResult.IsValid == false)
                throw new Exception();


            var LeaveType = _mapper.Map<LeaveType>(request.LeaveTypeDto);
            LeaveType = await _leaveRequestRepository.Add(LeaveType);
            return LeaveType.Id;
        }
    }
}
