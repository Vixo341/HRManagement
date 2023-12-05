namespace HRManagement.Application.Features.LeaveTypes.Queries.GetAllLeaveType;

public class LeaveTypeDto
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;
    
    public int DefaultDays { get; set; }

}