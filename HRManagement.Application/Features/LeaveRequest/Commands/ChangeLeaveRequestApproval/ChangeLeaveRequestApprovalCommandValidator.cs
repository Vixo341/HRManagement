using FluentValidation;
using HRManagement.Application.Features.LeaveRequest.Commands.ChangeLeaveRequestApproval;

namespace HRManagement.Application.DTOs.LeaveRequest.Validators;

public class ChangeLeaveRequestApprovalCommandValidator : AbstractValidator<ChangeLeaveRequestApprovalCommand>
{
    public ChangeLeaveRequestApprovalCommandValidator()
    {
        RuleFor(p => p.Approved)
            .NotNull()
            .WithMessage("Approval status cannot be null");
    }
}
