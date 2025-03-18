using LibraryManagement.API.Infrastrcture.ExceptionHandling;
using Newtonsoft.Json;

namespace PublishingHouseManagement.API.Infrastrcture.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                await ExceptionHandlingAsync(context, ex).ConfigureAwait(false);
            }
        }
        private async Task ExceptionHandlingAsync(HttpContext context, Exception exception)
        {
            var error = new ExceptionHandler(context, exception);
            var jsonResult = JsonConvert.SerializeObject(error);
            context.Response.Clear();
            context.Response.ContentType = "application/json";

            if (error.Status != null)
            {
                context.Response.StatusCode = error.Status.Value;
            }

            await context.Response.WriteAsync(jsonResult).ConfigureAwait(false);
        }
    }
}