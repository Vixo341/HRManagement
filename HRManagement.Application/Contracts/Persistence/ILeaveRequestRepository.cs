using HRManagement.Domain;

namespace HRManagement.Application.Contracts.Persistence;

public interface ILeaveRequestRepository : IGenericRepository<LeaveRequest>
{
    Task<IReadOnlyList<LeaveRequest>> GetLeaveRequestsWithDetails();
    Task<IReadOnlyList<LeaveRequest>> GetLeaveRequestWithDetails(int id);
    Task<IReadOnlyList<LeaveRequest>> GetLeaveRequestsWithDetailsByEmployeeId(string employeeId);
    
}