using HRManagement.Application.Contracts.Persistence;
using HRManagement.Domain;
using HRManagement.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace HRManagement.Persistence.Repositories;

public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
{
    public LeaveRequestRepository(HrDatabaseContext context) : base(context)
    {
    }

    public async Task<IReadOnlyList<LeaveRequest>> GetLeaveRequestsWithDetails()
    {
        return await _context.LeaveRequests
            .Include(l => l.LeaveType)
            .ToListAsync();
    }

    public async Task<IReadOnlyList<LeaveRequest>> GetLeaveRequestWithDetails(int id)
    {
        return await _context.LeaveRequests.Where(q=>q.Id == id)
            .Include(l => l.LeaveType)
            .ToListAsync();
    }

    public async Task<IReadOnlyList<LeaveRequest>> GetLeaveRequestsWithDetailsByEmployeeId(string employeeId)
    {
        return await _context.LeaveRequests.Where(q=>q.RequestingEmployeeId == employeeId)
            .Include(l => l.LeaveType)
            .ToListAsync();
    }
}