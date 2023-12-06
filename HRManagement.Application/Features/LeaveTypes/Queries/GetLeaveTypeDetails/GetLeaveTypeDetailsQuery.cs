using HRManagement.Application.Features.LeaveTypes.Queries.GetAllLeaveType;
using MediatR;

namespace HRManagement.Application.Features.LeaveTypes.Queries.GetLeaveTypeDetails;

public record GetLeaveTypeDetailsQuery(int Id) : IRequest<LeaveTypeDetailsDto>;
