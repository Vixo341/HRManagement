using AutoMapper;
using HRManagement.Application.Contracts.Persistence;
using HRManagement.Application.Exceptions;
using HRManagement.Application.Features.LeaveRequest.Queries.GetLeaveRequestDetail;
using HRManagement.Application.Features.LeaveRequests.Requests.Queries;
using MediatR;

namespace HRManagement.Application.Features.LeaveRequests.Handlers.Queries
{
    public class GetLeaveRequestDetailQueryHandler : IRequestHandler<GetLeaveRequestDetailQuery, LeaveRequestDetailsDto>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public GetLeaveRequestDetailQueryHandler(ILeaveRequestRepository leaveRequestRepository,
            IMapper mapper, IUserService userService)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
            this._userService = userService;
        }
        public async Task<LeaveRequestDetailsDto> Handle(GetLeaveRequestDetailQuery request, CancellationToken cancellationToken)
        {
            var leaveRequest = _mapper.Map<LeaveRequestDetailsDto>(await _leaveRequestRepository.GetLeaveRequestWithDetails(request.Id));

            if (leaveRequest == null)
                throw new NotFoundException(nameof(LeaveRequest), request.Id);

            // Add Employee details as needed
            leaveRequest.Employee = await _userService.GetEmployee(leaveRequest.RequestingEmployeeId);

            return leaveRequest;
        }
    }
}
