using System.ComponentModel.DataAnnotations.Schema;
using HRManagement.Domain.Common;

namespace HRManagement.Domain;

public class LeaveTypes : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    
    public int DefaultDays { get; set; }
}
