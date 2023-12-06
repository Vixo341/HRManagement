using System.ComponentModel.DataAnnotations;
using FluentValidation.Results;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace HRManagement.Application.Exceptions;

public class BadRequestException : Exception
{
    
    public BadRequestException(string message) : base(message)
    {
        
    }
    
    public BadRequestException(string message, ValidationResult validationResult) : base(message)
    {
        ValidationErrors = new();
        foreach (var validationError in validationResult.Errors)
        {
            ValidationErrors.Add(validationError.ErrorMessage);
        }
    }

    public List<string> ValidationErrors { get; set; }
}