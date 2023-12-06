using HRManagement.Domain;

namespace HRManagement.Application.Contracts.Persistence;

public interface ILeaveTypeRepository : IGenericRepository<LeaveType>  
{
    Task<bool> IsLeaveTypeUnique(string commandName);
}