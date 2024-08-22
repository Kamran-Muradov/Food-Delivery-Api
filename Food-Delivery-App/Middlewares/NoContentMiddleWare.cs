using Service.Helpers.Constants;
using Service.Helpers.Exceptions;

namespace Food_Delivery_App.Middlewares
{
    public class NoContentMiddleware
    {
        private readonly RequestDelegate _next;

        public NoContentMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await _next(context);

            if (context.Response.StatusCode == StatusCodes.Status204NoContent)
            {
                throw new NotFoundException(ResponseMessages.NotFound);
            }
        }
    }

}
