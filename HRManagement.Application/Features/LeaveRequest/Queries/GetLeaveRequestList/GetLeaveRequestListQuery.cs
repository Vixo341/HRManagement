using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using HRManagement.Application.DTOs.LeaveRequest;

namespace HRManagement.Application.Features.LeaveRequest.Queries.GetLeaveRequestList
{
    public class GetLeaveRequestListQuery : IRequest<List<LeaveRequestListDto>>
    {
        public bool IsLoggedInUser { get; set; }
    }
}
