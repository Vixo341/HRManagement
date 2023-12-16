using AutoMapper;
using HRManagement.BlazorUI.Models.LeaveAllocations;
using HRManagement.BlazorUI.Models.LeaveRequests;
using HRManagement.BlazorUI.Models.LeaveTypes;
using HRManagement.BlazorUI.Services.Base;

namespace HRManagement.BlazorUI.MappingProfiles;

public class MappingConfig : Profile
{
    public MappingConfig()
    {
        CreateMap<LeaveTypeDto, LeaveTypeVM>().ReverseMap();
        CreateMap<LeaveTypeDetailsDto, LeaveTypeVM>().ReverseMap();
        CreateMap<CreateLeaveTypeCommand, LeaveTypeVM>().ReverseMap();
        CreateMap<UpdateLeaveTypeCommand, LeaveTypeVM>().ReverseMap();

        CreateMap<LeaveRequestListDto, LeaveRequestVM>()
            .ForMember(q => q.DateRequested, opt => opt.MapFrom(x => x.DateRequested.DateTime))
            .ForMember(q => q.StartDate, opt => opt.MapFrom(x => x.StartDate.DateTime))
            .ForMember(q => q.EndDate, opt => opt.MapFrom(x => x.EndDate.DateTime))
            .ReverseMap();
        CreateMap<LeaveRequestDetailsDto, LeaveRequestVM>()
            .ForMember(q => q.DateRequested, opt => opt.MapFrom(x => x.DateRequested.DateTime))
            .ForMember(q => q.StartDate, opt => opt.MapFrom(x => x.StartDate.DateTime))
            .ForMember(q => q.EndDate, opt => opt.MapFrom(x => x.EndDate.DateTime))
            .ReverseMap();
        CreateMap<CreateLeaveRequestCommand, LeaveRequestVM>().ReverseMap();
        CreateMap<UpdateLeaveRequestCommand, LeaveRequestVM>().ReverseMap();

        CreateMap<LeaveAllocationDto, LeaveAllocationVM>().ReverseMap();
        CreateMap<LeaveAllocationDetailsDto, LeaveAllocationVM>().ReverseMap();
        CreateMap<CreateLeaveAllocationCommand, LeaveAllocationVM>().ReverseMap();
        CreateMap<UpdateLeaveAllocationCommand, LeaveAllocationVM>().ReverseMap();
    }
}