using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HRManagement.Application.Contracts.Persistence;
using HRManagement.Application.Features.LeaveRequest.Shared;
using HRManagement.Application.Features.LeaveRequests.Requests.Commands;

namespace HRManagement.Application.DTOs.LeaveRequest.Validators
{
    public class CreateLeaveRequestCommandValidator : AbstractValidator<CreateLeaveRequestCommand>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public CreateLeaveRequestCommandValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;
            Include(new BaseLeaveRequestValidator(_leaveTypeRepository));
        }
    }
}
