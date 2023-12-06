using AutoMapper;
using HRManagement.Application.Contracts.Persistence;
using HRManagement.Application.Features.LeaveTypes.Queries.GetAllLeaveType;
using MediatR;

namespace HRManagement.Application.Features.LeaveTypes.Queries.GetLeaveTypeDetails;

public class GetLeaveTypeDetailsQueryHandler :IRequestHandler<GetLeaveTypeDetailsQuery, LeaveTypeDetailsDto>
{
    private readonly IMapper _mapper;
    private readonly ILeaveTypeRepository _leaveTypeRepository;

    public GetLeaveTypeDetailsQueryHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
    {
        _mapper = mapper;
        _leaveTypeRepository = leaveTypeRepository;
    }
    

    public async Task<LeaveTypeDetailsDto> Handle(GetLeaveTypeDetailsQuery request, CancellationToken cancellationToken)
    {
        var leaveTypes = await _leaveTypeRepository.GetByIdAsync(request.Id);
        var data = _mapper.Map<LeaveTypeDetailsDto>(leaveTypes);

        return data;
    }
}