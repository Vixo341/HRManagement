using AutoMapper;
using HRManagement.Application.Features.LeaveTypes.Commands.CreateLeaveType;
using HRManagement.Application.Features.LeaveTypes.Commands.UpdateLeaveType;
using HRManagement.Application.Features.LeaveTypes.Queries.GetAllLeaveType;
using HRManagement.Application.Features.LeaveTypes.Queries.GetLeaveTypeDetails;
using HRManagement.Domain;

namespace HRManagement.Application.MappingProfiles;

public class LeaveTypeProfile : Profile
{
    public LeaveTypeProfile()
    {
        CreateMap<LeaveTypeDto, LeaveType>().ReverseMap();
        CreateMap<LeaveType, LeaveTypeDto>();
        CreateMap<CreateLeaveTypeCommand, LeaveType>();
        CreateMap<UpdateLeaveTypeCommand, LeaveType>();
    }
}