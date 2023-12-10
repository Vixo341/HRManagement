using AutoMapper;

using MediatR;
using System.Net.Mail;
using System.Security.Claims;
using HRManagement.Application.Contracts.Email;
using HRManagement.Application.Contracts.Persistence;
using HRManagement.Application.DTOs.LeaveRequest.Validators;
using HRManagement.Application.Exceptions;
using HRManagement.Application.Features.LeaveRequests.Requests.Commands;
using HRManagement.Application.Models.Email;

namespace HRManagement.Application.Features.LeaveRequests.Handlers.Commands
{
    public class CreateLeaveRequestCommandHandler : IRequestHandler<CreateLeaveRequestCommand, Unit>
    {
        private readonly IEmailSender _emailSender;
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;

        public CreateLeaveRequestCommandHandler(IEmailSender emailSender,
            IMapper mapper, ILeaveTypeRepository leaveTypeRepository, ILeaveRequestRepository leaveRequestRepository, ILeaveAllocationRepository leaveAllocationRepository)
        {
            _emailSender = emailSender;
            _mapper = mapper;
            this._leaveTypeRepository = leaveTypeRepository;
            this._leaveRequestRepository = leaveRequestRepository;
            this._leaveAllocationRepository = leaveAllocationRepository;
        }

        public async Task<Unit> Handle(CreateLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateLeaveRequestCommandValidator(_leaveTypeRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
                throw new BadRequestException("Invalid Leave Request", validationResult);



            // Create leave request
            var leaveRequest = _mapper.Map<Domain.LeaveRequest>(request);
            leaveRequest.DateRequested = DateTime.Now;
            await _leaveRequestRepository.AddAsync(leaveRequest);

            // send confirmation email
            try
            {
                var email = new EmailMessage
                {
                    To = string.Empty, /* Get email from employee record */
                    Body = $"Your leave request for {request.StartDate:D} to {request.EndDate:D} " +
                        $"has been submitted successfully.",
                    Subject = "Leave Request Submitted"
                };

                await _emailSender.SendEmail(email);
            }
            catch (Exception)
            {
                //// Log or handle error,
            }

            return Unit.Value;
        }
    }
}
