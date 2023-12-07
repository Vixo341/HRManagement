using HRManagement.Domain;

namespace HRManagement.Application.Contracts.Persistence;

public interface ILeaveAllocationRepository : IGenericRepository<LeaveAllocation>
{
    Task<bool> CheckAllocation(string userId, int leaveTypeId, int period);
    Task<LeaveAllocation?> GetLeaveAllocationByEmployeeAndType(string employeeId, int leaveTypeId);
    Task<LeaveAllocation?> GetLeaveAllocationsWithDetails(int id);

    Task AddAllocation(List<LeaveAllocation> leaveAllocations);
    Task<IReadOnlyList<LeaveAllocation>> GetLeaveAllocationsWithDetails();
    Task<IReadOnlyList<LeaveAllocation>> GetLeaveAllocationsWithDetailsByEmployee(string employeeId);
}