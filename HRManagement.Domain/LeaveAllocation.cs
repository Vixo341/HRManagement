using System.ComponentModel.DataAnnotations.Schema;
using HRManagement.Domain.Common;

namespace HRManagement.Domain;

public class LeaveAllocation : BaseEntity
{
    public int NumberOfDays { get; set; }
    public LeaveTypes? LeaveType { get; set; }
    public int LeaveTypeId { get; set; }
    public int Period { get; set; }
}