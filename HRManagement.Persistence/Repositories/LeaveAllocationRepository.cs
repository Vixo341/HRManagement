using HRManagement.Application.Contracts.Persistence;
using HRManagement.Domain;
using HRManagement.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace HRManagement.Persistence.Repositories;

public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
{
    public LeaveAllocationRepository(HrDatabaseContext context) : base(context)
    {
    }

    public async Task<bool> CheckAllocation(string userId, int leaveTypeId, int period)
    {
       return await _context.LeaveAllocations.AnyAsync(q => q.LeaveTypeId == leaveTypeId 
                                                            && q.Period == period && 
                                                            q.EmployeeId == userId);
    }

    public async Task<LeaveAllocation?> GetLeaveAllocationByEmployeeAndType(string employeeId, int leaveTypeId)
    {
        return await _context.LeaveAllocations.Include(l => l.LeaveType)
            .FirstOrDefaultAsync(x => x.EmployeeId == employeeId && x.LeaveTypeId == leaveTypeId);
    }

    public async Task AddAllocation(List<LeaveAllocation> leaveAllocations)
    {
        await _context.AddRangeAsync(leaveAllocations);
        await _context.SaveChangesAsync();
    }

    public async Task<IReadOnlyList<LeaveAllocation>> GetLeaveAllocationsWithDetails()
    {
        return await _context.LeaveAllocations
            .Include(l => l.LeaveType)
            .ToListAsync();
    }

    public async Task<IReadOnlyList<LeaveAllocation>> GetLeaveAllocationsWithDetailsByEmployee(string employeeId)
    {
        return await _context.LeaveAllocations.Where(x=>x.EmployeeId == employeeId)
            .Include(l => l.LeaveType)
            .ToListAsync();
    }

    public async Task<LeaveAllocation?>GetLeaveAllocationsWithDetails(int id)
    {
        return await _context.LeaveAllocations.Include(l => l.LeaveType)
            .FirstOrDefaultAsync(x => x.Id == id);
    }
}