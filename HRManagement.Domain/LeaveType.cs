﻿using System.ComponentModel.DataAnnotations.Schema;
using HRManagement.Domain.Common;

namespace HRManagement.Domain;

[Table("LeaveType")]
public class LeaveType : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    
    public int DefaultDays { get; set; }
}
