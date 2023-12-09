﻿using AutoMapper;
using HR.LeaveManagement.Application.DTOs;

using MediatR;
using System.Threading;
using System.Threading.Tasks;

using HRManagement.Application.Contracts.Persistence;
using HRManagement.Application.Exceptions;
using HRManagement.Application.Features.LeaveAllocation.Queries.GetLeaveAllocationDetails;

namespace HRManagement.Application.Features.LeaveAllocations.Handlers.Queries
{
    public class GetLeaveAllocationDetailRequestHandler : IRequestHandler<GetLeaveAllocationDetailQuery, LeaveAllocationDetailsDto>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly IMapper _mapper;

        public GetLeaveAllocationDetailRequestHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _mapper = mapper;
        }
        public async Task<LeaveAllocationDetailsDto> Handle(GetLeaveAllocationDetailQuery request, CancellationToken cancellationToken)
        {
            var leaveAllocation = await _leaveAllocationRepository.GetLeaveAllocationsWithDetails(request.Id);
            if (leaveAllocation == null)
                throw new NotFoundException(nameof(LeaveAllocation), request.Id);

            return _mapper.Map<LeaveAllocationDetailsDto>(leaveAllocation);
        }
    }
}
