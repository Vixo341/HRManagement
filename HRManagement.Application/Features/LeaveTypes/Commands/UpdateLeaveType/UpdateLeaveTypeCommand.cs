using MediatR;

namespace HRManagement.Application.Features.LeaveTypes.Commands.UpdateLeaveType;

public class UpdateLeaveTypeCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int DefaultDays { get; set; }
    
}