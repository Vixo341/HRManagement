using AutoMapper;
using HRManagement.Application.Contracts.Persistence;
using HRManagement.Application.Exceptions;
using HRManagement.Domain;
using MediatR;

namespace HRManagement.Application.Features.LeaveTypes.Commands.DeleteLeaveType;

public class DeleteLeaveTypeCommandHandler : IRequestHandler<DeleteLeaveTypeCommand, Unit>
{
    private readonly IMapper _mapper;
    private readonly ILeaveTypeRepository _leaveTypeRepository;

    public DeleteLeaveTypeCommandHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
    {
        _mapper = mapper;
        _leaveTypeRepository = leaveTypeRepository;
    }
    
    
    public async Task<Unit> Handle(DeleteLeaveTypeCommand request, CancellationToken cancellationToken)
    {
        var validator = new DeleteLeaveTypeCommandValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        
        if (validationResult.Errors.Any()) throw new BadRequestException("Validation errors occurred.", validationResult);
        
        var leaveTypeToDelete = await _leaveTypeRepository.GetByIdAsync(request.Id) ?? 
            throw new NotFoundException(nameof(LeaveType), request.Id);
        
        
        await _leaveTypeRepository.DeleteAsync(leaveTypeToDelete);
        
        return Unit.Value;
    }
}