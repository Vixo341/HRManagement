using System.Net;
using HRManagement.Api.Models;
using HRManagement.Application.Exceptions;

namespace HRManagement.Api.Middleware;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    
    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    
public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
          HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
          CustomProblemDetails problem = new();
          switch (exception)
          {
              case BadRequestException badRequestException:
                 statusCode = HttpStatusCode.BadRequest; 
                    problem = new CustomProblemDetails()
                    {
                        Title = badRequestException.InnerException?.Message ?? badRequestException.Message,
                        Status = (int)statusCode,
                        Detail = badRequestException.InnerException?.Message ?? badRequestException.Message,
                        Type = nameof(BadRequestException),
                        Errors = badRequestException.ValidationErrors
                    };
                  break;
                case NotFoundException NotFound:
                    statusCode = HttpStatusCode.NotFound;
                    problem = new CustomProblemDetails()
                    {
                        Title = NotFound.Message,
                        Status = (int)statusCode,
                        Detail = NotFound.InnerException?.Message ?? exception.Message,
                        Type = nameof(NotFoundException)
                    };
                    break;
                default:
                    problem = new CustomProblemDetails()
                    {
                        Title = exception.Message,
                        Status = (int)statusCode,
                        Detail = exception.InnerException?.Message ?? exception.Message,
                        Type = nameof(HttpStatusCode.InternalServerError)
                    };
                    break;
          }
          
          context.Response.StatusCode = (int)statusCode;
          await context.Response.WriteAsJsonAsync(problem);
    }
}
