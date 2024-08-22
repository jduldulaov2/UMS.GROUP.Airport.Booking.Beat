﻿using UMS.GROUP.Airport.Booking.Application.Common.Exceptions;
using UMS.GROUP.Airport.Booking.Application.Common.Models;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace UMS.GROUP.Airport.Booking.Web.Infrastructure;

public class CustomExceptionHandler : IExceptionHandler
{
    private readonly Dictionary<Type, Func<HttpContext, Exception, Task>> _exceptionHandlers;

    public CustomExceptionHandler()
    {
        // Register known exception types and handlers.
        _exceptionHandlers = new()
            {
                { typeof(ValidationException), HandleValidationException },
                { typeof(NotFoundException), HandleNotFoundException },
                { typeof(UnauthorizedAccessException), HandleUnauthorizedAccessException },
                { typeof(ForbiddenAccessException), HandleForbiddenAccessException },
                { typeof(DatabaseIntegrityException), HandleDatabaseIntegrityException },
                { typeof(DatabaseValueChangedException), HandleDatabaseValueChangedException },
                { typeof(BusinessRuleException), HandleBusinessRuleException },
                { typeof(QueryNotFoundException), HandleQueryNotFoundException },
            };
    }

    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        var exceptionType = exception.GetType();

        if (_exceptionHandlers.ContainsKey(exceptionType))
        {
            await _exceptionHandlers[exceptionType].Invoke(httpContext, exception);
            return true;
        }

        return false;
    }

    private async Task HandleValidationException(HttpContext httpContext, Exception ex)
    {
        var exception = (ValidationException)ex;

        httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;

        await httpContext.Response.WriteAsJsonAsync(new ValidationProblemDetails(exception.Errors)
        {
            Status = StatusCodes.Status400BadRequest,
            Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1",
            Title = "BadRequest",
            Detail = exception.Message
        });
    }

    private async Task HandleNotFoundException(HttpContext httpContext, Exception ex)
    {
        var exception = (NotFoundException)ex;

        httpContext.Response.StatusCode = StatusCodes.Status404NotFound;

        await httpContext.Response.WriteAsJsonAsync(new ProblemDetails()
        {
            Status = StatusCodes.Status404NotFound,
            Type = "https://tools.ietf.org/html/rfc7231#section-6.5.4",
            Title = "NotFound",
            Detail = exception.Message
        });
    }

    private async Task HandleUnauthorizedAccessException(HttpContext httpContext, Exception ex)
    {
        httpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;

        await httpContext.Response.WriteAsJsonAsync(new ProblemDetails
        {
            Status = StatusCodes.Status401Unauthorized,
            Title = "Unauthorized",
            Type = "https://tools.ietf.org/html/rfc7235#section-3.1",
            Detail = ex.Message
        });
    }

    private async Task HandleForbiddenAccessException(HttpContext httpContext, Exception ex)
    {
        httpContext.Response.StatusCode = StatusCodes.Status403Forbidden;

        await httpContext.Response.WriteAsJsonAsync(new ProblemDetails
        {
            Status = StatusCodes.Status403Forbidden,
            Title = "Forbidden",
            Type = "https://tools.ietf.org/html/rfc7231#section-6.5.3",
            Detail = ex.Message
        });
    }

    private async Task HandleDatabaseIntegrityException(HttpContext httpContext, Exception ex)
    {
        httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

        await httpContext.Response.WriteAsJsonAsync(new ProblemDetails
        {
            Status = StatusCodes.Status500InternalServerError,
            Title = "DatabaseIntegrity",
            Type = "https://tools.ietf.org/html/rfc7231#section-6.5.3",
            Detail = ex.Message
        });
    }

    private async Task HandleDatabaseValueChangedException(HttpContext httpContext, Exception ex)
    {
        var exception = (DatabaseValueChangedException)ex;

        httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

        await httpContext.Response.WriteAsJsonAsync(new ProblemDetails
        {
            Status = StatusCodes.Status500InternalServerError,
            Title = "DatabaseValueChanged",
            Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1",
            Detail = exception.Message
        });
    }

    private async Task HandleBusinessRuleException(HttpContext httpContext, Exception ex)
    {
        var exception = (BusinessRuleException)ex;

        httpContext.Response.ContentType = "application/json";
        httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;

        // @@todo: follow this pattern to every handlers
        ErrorResult result = new()
        {
            Message = exception.Message
        };

        // await httpContext.Response.WriteAsJsonAsync(new ProblemDetails
        // {
        //     Status = StatusCodes.Status400BadRequest,
        //     Title = "BadRequest",
        //     Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1",
        //     Detail = exception.Message
        // });

        await httpContext.Response.WriteAsync(result.ToString());
    }

    private async Task HandleQueryNotFoundException(HttpContext httpContext, Exception ex)
    {
        var exception = (NotFoundException)ex;

        httpContext.Response.StatusCode = StatusCodes.Status404NotFound;

        await httpContext.Response.WriteAsJsonAsync(new ProblemDetails()
        {
            Status = StatusCodes.Status404NotFound,
            Title = "QueryNotFound",
            Type = "https://tools.ietf.org/html/rfc7231#section-6.5.4",
            Detail = exception.Message
        });
    }
}
