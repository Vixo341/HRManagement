using AutoMapper;
using HRManagement.Application.Features.LeaveAllocation.Queries.GetLeaveAllocationDetails;
using HRManagement.Application.Features.LeaveAllocation.Queries.GetLeaveAllocations;
using HRManagement.Application.Features.LeaveAllocations.Requests.Commands;
using HRManagement.Domain;


namespace HRManagement.Application.MappingProfiles
{
    public class LeaveAllocationProfile : Profile
    {
        public LeaveAllocationProfile()
        {
            CreateMap<LeaveAllocationDto, LeaveAllocation>().ReverseMap();
            CreateMap<LeaveAllocation, LeaveAllocationDetailsDto>();
            CreateMap<CreateLeaveAllocationCommand, LeaveAllocation>();
            CreateMap<UpdateLeaveAllocationCommand, LeaveAllocation>();
        }
    }
}
