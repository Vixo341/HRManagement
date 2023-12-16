using HRManagement.BlazorUI.Services.Base;

namespace HRManagement.BlazorUI.Contracts;

public interface ILeaveAllocationService
{
    Task<Response<Guid>> CreateLeaveAllocations(int leaveTypeId);
}