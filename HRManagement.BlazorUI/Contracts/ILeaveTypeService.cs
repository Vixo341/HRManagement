using HRManagement.BlazorUI.Models.LeaveTypes;
using HRManagement.BlazorUI.Services.Base;

namespace HRManagement.BlazorUI.Contracts;

public interface ILeaveTypeService
{
    Task<List<LeaveTypeVM>> GetLeaveTypes();
    Task<LeaveTypeVM> GetLeaveTypeDetails(int id);
    
    Task<Response<Guid>> CreateLeaveType(LeaveTypeVM leaveType);
    Task<Response<Guid>> UpdateLeaveType(int id, LeaveTypeVM leaveType);
    Task<Response<Guid>> DeleteLeaveType(int id);
}