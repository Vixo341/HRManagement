﻿using MediatR;

namespace HRManagement.Application.Features.LeaveTypes.Queries.GetLeaveTypeDetails;

public class LeaveTypeDetailsDto : IRequest<LeaveTypeDetailsDto>
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;
    
    public int DefaultDays { get; set; }
    public DateTime? DateCreated { get; set; }
    public DateTime? DateModified { get; set; }

}