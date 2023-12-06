using AutoMapper;
using HRManagement.Application.Contracts.Persistence;
using MediatR;

namespace HRManagement.Application.Features.LeaveTypes.Queries.GetAllLeaveType;

public class GetLeaveTypesQueryHandler :IRequestHandler<GetLeaveTypesQuery, List<LeaveTypeDto>>
{
    private readonly IMapper _mapper;
    private readonly ILeaveTypeRepository _leaveTypeRepository;

    public GetLeaveTypesQueryHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
    {
        _mapper = mapper;
        _leaveTypeRepository = leaveTypeRepository;
    }
    
    public async Task<List<LeaveTypeDto>> Handle(GetLeaveTypesQuery request, CancellationToken cancellationToken)
    {
        var leaveTypes = await _leaveTypeRepository.GetAllAsync();
        var data = _mapper.Map<List<LeaveTypeDto>>(leaveTypes);

        return data;
    }
}