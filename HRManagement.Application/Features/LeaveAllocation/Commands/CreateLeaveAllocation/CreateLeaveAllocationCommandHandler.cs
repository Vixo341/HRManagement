using AutoMapper;
using HRManagement.Application.Contracts.Persistence;
using HRManagement.Application.DTOs.LeaveAllocation.Validators;
using HRManagement.Application.Exceptions;
using HRManagement.Application.Features.LeaveAllocations.Requests.Commands;
using MediatR;

namespace HRManagement.Application.Features.LeaveAllocations.Handlers.Commands
{
    public class CreateLeaveAllocationCommandHandler : IRequestHandler<CreateLeaveAllocationCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public CreateLeaveAllocationCommandHandler(IMapper mapper,
            ILeaveAllocationRepository leaveAllocationRepository, ILeaveTypeRepository leaveTypeRepository)
        {
            _mapper = mapper;
            this._leaveAllocationRepository = leaveAllocationRepository;
            this._leaveTypeRepository = leaveTypeRepository;
        }

        public async Task<Unit> Handle(CreateLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateLeaveAllocationCommandValidator(_leaveTypeRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
                throw new BadRequestException("Invalid Leave Allocation Request", validationResult);
            var leaveAllocation = _mapper.Map<Domain.LeaveAllocation>(request);
            await _leaveAllocationRepository.AddAsync(leaveAllocation);
            
            return Unit.Value;
        }
    }
}
