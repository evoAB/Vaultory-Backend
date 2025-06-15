using System.Net;

namespace Vaultory.API.Middlewares;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    public readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (FluentValidation.ValidationException ex)
        {
            _logger.LogError(ex, "Validation exception occurred");

            context.Response.StatusCode = StatusCodes.Status400BadRequest;

            var errors = ex.Errors.Select(e => e.ErrorMessage);

            await context.Response.WriteAsJsonAsync(new
            {
                errors
            });

            return;
        }
        catch (Exception e)
        {
            _logger.LogError(e, "An unhandled exception occurred");

            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            await context.Response.WriteAsJsonAsync(new
            {
                Message = "Something went wrong. Please try again later."
            });
        }
    }
}