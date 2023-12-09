using MediatR;

namespace HRManagement.Application.Features.LeaveTypes.Queries.GetAllLeaveType;

public record GetLeaveTypesQuery : IRequest<List<LeaveTypeDto>>;
