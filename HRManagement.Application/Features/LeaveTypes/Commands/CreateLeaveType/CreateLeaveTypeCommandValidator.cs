using FluentValidation;
using HRManagement.Application.Contracts.Persistence;

namespace HRManagement.Application.Features.LeaveTypes.Commands.CreateLeaveType;

public class CreateLeaveTypeCommandValidator : AbstractValidator<CreateLeaveTypeCommand>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    public CreateLeaveTypeCommandValidator( ILeaveTypeRepository leaveTypeRepository)
    {
        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .MaximumLength(20).WithMessage("{PropertyName} must not exceed 50 characters.");
        RuleFor(p => p.DefaultDays)
            .GreaterThan(1).WithMessage("{PropertyName} must be greater than 1.")
            .LessThan(100).WithMessage("{PropertyName} must be less than 100.");
        
        
        RuleFor(q=>q).MustAsync(LeaveTypeNameUnique).WithMessage("Leave type name must be unique.");
        
        
        _leaveTypeRepository = leaveTypeRepository;
    }

    private Task<bool> LeaveTypeNameUnique(CreateLeaveTypeCommand command, CancellationToken token)
    {
      return _leaveTypeRepository.IsLeaveTypeUnique(command.Name);
    }
}