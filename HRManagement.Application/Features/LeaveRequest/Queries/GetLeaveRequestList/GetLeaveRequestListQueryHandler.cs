using AutoMapper;
using HRManagement.Application.Contracts.Persistence;
using HRManagement.Application.DTOs.LeaveRequest;
using HRManagement.Application.Features.LeaveRequest.Queries.GetLeaveRequestList;
using MediatR;

namespace HRManagement.Application.Features.LeaveRequests.Handlers.Queries
{
    public class GetLeaveRequestListQueryHandler : IRequestHandler<GetLeaveRequestListQuery, List<LeaveRequestListDto>>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;

        public GetLeaveRequestListQueryHandler(ILeaveRequestRepository leaveRequestRepository,
            IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
        }

        public async Task<List<LeaveRequestListDto>> Handle(GetLeaveRequestListQuery request, CancellationToken cancellationToken)
        {
            
               var leaveRequests = (List<Domain.LeaveRequest>)await _leaveRequestRepository.GetLeaveRequestsWithDetails();
               var requests = _mapper.Map<List<LeaveRequestListDto>>(leaveRequests);
            
            return requests;
        }
    }
}
