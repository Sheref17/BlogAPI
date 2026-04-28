using ApplicationLayer.CustomExceptions.AuthourizedExceptions;
using ApplicationLayer.CustomExceptions.ConflictExceptions;
using ApplicationLayer.CustomExceptions.NotFoundExceptions;
using FluentValidation;

namespace BlogSystem.Middlewares
{
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
                context.Response.ContentType = "application/json";

                List<string> errors = new List<string> { ex.Message };

                switch (ex)
                {
                    case NotFoundException:
                        context.Response.StatusCode = StatusCodes.Status404NotFound;
                        break;

                    case ValidationException validationException:
                        context.Response.StatusCode = StatusCodes.Status400BadRequest;

                        errors = validationException.Errors
                            .Select(e => e.ErrorMessage)
                            .ToList();
                        break;

                    case ConflictsException:
                        context.Response.StatusCode = StatusCodes.Status409Conflict;
                        break;

                    case ForbiddenException:
                    case UnauthorizedAccessException:
                        context.Response.StatusCode = StatusCodes.Status403Forbidden;
                        break;

                    case ArgumentException:
                        context.Response.StatusCode = StatusCodes.Status400BadRequest;
                        break;

                    default:
                        context.Response.StatusCode = StatusCodes.Status500InternalServerError;

                        errors = new List<string>
                        {
                            "An unexpected error occurred."
                        };
                        break;
                }

                var response = new
                {
                    success = false,
                    errors
                };

                await context.Response.WriteAsJsonAsync(response);
            }
        }
    }
}