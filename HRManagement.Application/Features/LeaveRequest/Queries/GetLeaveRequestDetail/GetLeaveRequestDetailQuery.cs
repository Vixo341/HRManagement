using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using HRManagement.Application.Features.LeaveRequest.Queries.GetLeaveRequestDetail;

namespace HRManagement.Application.Features.LeaveRequests.Requests.Queries;

public class GetLeaveRequestDetailQuery : IRequest<LeaveRequestDetailsDto>
{
    public int Id { get; set; }
}
