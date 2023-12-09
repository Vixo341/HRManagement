using AutoMapper;
using HRManagement.Application.DTOs.LeaveRequest;
using HRManagement.Application.Features.LeaveRequest.Commands.UpdateLeaveRequest;
using HRManagement.Application.Features.LeaveRequest.Queries.GetLeaveRequestDetail;
using HRManagement.Application.Features.LeaveRequests.Requests.Commands;
using HRManagement.Domain;


namespace HRManagement.Application.MappingProfiles
{
    public class LeaveRequestProfile : Profile
    {
        public LeaveRequestProfile()
        {
            CreateMap<LeaveRequestListDto, LeaveRequest>().ReverseMap();
            CreateMap<LeaveRequestDetailsDto, LeaveRequest>().ReverseMap();
            CreateMap<LeaveRequest, LeaveRequestDetailsDto>();
            CreateMap<CreateLeaveRequestCommand, LeaveRequest>();
            CreateMap<UpdateLeaveRequestCommand, LeaveRequest>();
        }
    }
}
