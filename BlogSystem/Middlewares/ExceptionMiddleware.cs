using ApplicationLayer.CustomExceptions;

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
                var response = new { success = false, errors = new List<string> { ex.Message } };
                switch (ex)
                {
                    case NotFoundException:
                        context.Response.StatusCode = StatusCodes.Status404NotFound;
                        break;

                    case ArgumentException:
                        context.Response.StatusCode = StatusCodes.Status400BadRequest;
                        break;


                    case UnauthorizedAccessException:
                        context.Response.StatusCode = StatusCodes.Status403Forbidden;
                        break;

                    default:
                        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                        break;
                }
                await context.Response.WriteAsJsonAsync(response);





            }
        }
    }
}
