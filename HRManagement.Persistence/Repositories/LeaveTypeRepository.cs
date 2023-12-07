using HRManagement.Application.Contracts.Persistence;
using HRManagement.Domain;
using HRManagement.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace HRManagement.Persistence.Repositories;

public class LeaveTypeRepository : GenericRepository<LeaveType>, ILeaveTypeRepository
{
    public LeaveTypeRepository(HrDatabaseContext context) : base(context)
    {
    }

    public async Task<bool> IsLeaveTypeUnique(string commandName)
    {
        return await _context.LeaveTypes.AnyAsync(lt => lt.Name == commandName);
    }
}