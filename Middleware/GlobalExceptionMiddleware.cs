using System.Net;
using System.Text.Json;
using OrderApi.Responses;
using OrderApi.Exceptions;

namespace OrderApi.Middleware;

public class GlobalExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<GlobalExceptionMiddleware> _logger;
    private readonly IWebHostEnvironment _env;

    public GlobalExceptionMiddleware(
        RequestDelegate next,
        ILogger<GlobalExceptionMiddleware> logger,
        IWebHostEnvironment env)
    {
        _next = next;
        _logger = logger;
        _env = env;
    }

     public async Task InvokeAsync(HttpContext context)
{
    try
    {
        await _next(context);
    }
    catch (NotFoundException ex)
    {
        _logger.LogWarning(ex, "Resource not found.");

        await WriteErrorAsync(context, 404, ex.Message);
    }
    catch (BadRequestException ex)
    {
        _logger.LogWarning(ex, "Bad request.");

        await WriteErrorAsync(context, 400, ex.Message);
    }
    catch (Exception ex)
    {
        _logger.LogError(ex, "Unhandled exception occurred.");

        await WriteErrorAsync(context, 500, "An unexpected error occurred.",
            _env.IsDevelopment() ? ex.Message : null);
    }
}


    
    private Task WriteErrorAsync(HttpContext context,
                              int statusCode,
                              string message,
                              string? detail = null)
{
    context.Response.ContentType = "application/json";
    context.Response.StatusCode = statusCode;

    var response = new ErrorResponse
    {
        Success = false,
        Message = message,
        Detail = detail
    };

    var json = JsonSerializer.Serialize(response);
    return context.Response.WriteAsync(json);
}



    private Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        var response = new ErrorResponse
        {
            Success = false,
            Message = "An unexpected error occurred.",
            Detail = _env.IsDevelopment() ? exception.Message : null
        };

        var json = JsonSerializer.Serialize(response);

        return context.Response.WriteAsync(json);
    }
}


