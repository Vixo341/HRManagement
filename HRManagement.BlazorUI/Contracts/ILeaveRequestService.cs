using HRManagement.BlazorUI.Models.LeaveRequests;
using HRManagement.BlazorUI.Services.Base;

namespace HRManagement.BlazorUI.Contracts;

public interface ILeaveRequestService
{
    Task<Response<Guid>> CreateLeaveRequest(LeaveRequestVM leaveRequest);
    Task<LeaveRequestVM> GetLeaveRequest(int id);
    Task DeleteLeaveRequest(int id);
    Task<Response<Guid>> ApproveLeaveRequest(int id, bool approved);
    Task<Response<Guid>> CancelLeaveRequest(int id);
}