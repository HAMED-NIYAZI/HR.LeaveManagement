using HR.LeaveManagement.Application.DTOs.LeaveRequest;
using HR.LeaveManagement.Application.Features.LeaveRequests.Requests.Commands;
using HR.LeaveManagement.Application.Features.LeaveRequests.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HR.LeaveManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveRequestsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public LeaveRequestsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<LeaveRequestsController>
        [HttpGet]
        public async Task<ActionResult<List<LeaveRequestListDto>>> Get()
        {
            var request = new GetLeaveRequestListRequest();
            var responses = await _mediator.Send(request);
            return Ok(responses);
        }

        // GET api/<LeaveRequestsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveRequestDto>> Get(int id)
        {
            var request = new GetLeaveRequeatDetailRequest {Id=id };
            var responses = await _mediator.Send(request);
            return Ok(responses);
        }

        // POST api/<LeaveRequestsController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateLeaveRequestDto leaveRequestDto)
        {
            var command = new CreateLeaveRequestCommand { LeaveRequestDto = leaveRequestDto};
            await _mediator.Send(command);
            return NoContent();
        }

        // PUT api/<LeaveRequestsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put( int id, [FromBody] UpdateLeaveRequestDto updateLeaveRequest)
        {
            var command = new UpdateLeaveRequestCommand { Id = id, LeaveRequestDto = updateLeaveRequest };
            await _mediator.Send(command);
            return NoContent() ;
        }

        // PUT api/<LeaveRequestsController>/ChangeApproval
        [HttpPut("{changeApproval}/{id}")]
        public async Task<ActionResult> ChangeApproval(int id, [FromBody] ChangeLeaveRequestApprovalDto changeLeaveRequestApproval)
        {
            var command = new UpdateLeaveRequestCommand { Id = id, ChangeLeaveRequestApprovalDto = changeLeaveRequestApproval };
            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE api/<LeaveRequestsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteLeaveRequestCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
