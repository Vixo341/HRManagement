
using HR.LeaveManagement.Application.DTOs.LeaveRequest;
using MediatR;

namespace HRManagement.Application.Features.LeaveRequests.Requests.Commands
{
    public class CreateLeaveRequestCommand : BaseLeaveRequest, IRequest<Unit>
    {
        public string RequestComments { get; set; } = string.Empty;
    }
}
