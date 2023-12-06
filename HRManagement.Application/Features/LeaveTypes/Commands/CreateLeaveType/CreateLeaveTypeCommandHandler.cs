using System.ComponentModel.DataAnnotations;
using AutoMapper;
using FluentValidation;
using HRManagement.Application.Contracts.Persistence;
using HRManagement.Application.Exceptions;
using HRManagement.Domain;
using MediatR;

namespace HRManagement.Application.Features.LeaveTypes.Commands.CreateLeaveType;

public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, int>
{
    private readonly IMapper _mapper;
    private readonly ILeaveTypeRepository _leaveTypeRepository;

    public CreateLeaveTypeCommandHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
    {
        _mapper = mapper;
        _leaveTypeRepository = leaveTypeRepository;
    }
    
    
    public async Task<int> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateLeaveTypeCommandValidator(_leaveTypeRepository);
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        
        if (validationResult.Errors.Any()) throw new BadRequestException("Validation errors occurred.", validationResult);
        var leaveTypeCreate = _mapper.Map<LeaveType>(request);
        
        await _leaveTypeRepository.AddAsync(leaveTypeCreate);
        
        return leaveTypeCreate.Id;
    }
}