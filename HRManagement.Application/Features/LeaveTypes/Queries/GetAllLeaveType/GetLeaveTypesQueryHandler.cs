using AutoMapper;
using HRManagement.Application.Contracts.Logging;
using HRManagement.Application.Contracts.Persistence;
using MediatR;

namespace HRManagement.Application.Features.LeaveTypes.Queries.GetAllLeaveType;

public class GetLeaveTypesQueryHandler :IRequestHandler<GetLeaveTypesQuery, List<LeaveTypeDto>>
{
    private readonly IMapper _mapper;
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    private readonly IAppLogger<GetLeaveTypesQueryHandler> _logger;

    public GetLeaveTypesQueryHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository, IAppLogger<GetLeaveTypesQueryHandler> logger)
    {
        _mapper = mapper;
        _leaveTypeRepository = leaveTypeRepository;
        _logger = logger;
    }
    
    public async Task<List<LeaveTypeDto>> Handle(GetLeaveTypesQuery request, CancellationToken cancellationToken)
    {
        var leaveTypes = await _leaveTypeRepository.GetAllAsync();
        var data = _mapper.Map<List<LeaveTypeDto>>(leaveTypes);
        _logger.LogInformation("All Leave Types are successfully retrieved");
        return data;
    }
}