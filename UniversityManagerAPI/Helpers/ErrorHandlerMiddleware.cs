using System.Net;
using System.Text.Json;

namespace UniversityManagerAPI.Helpers
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlerMiddleware> logger;
        public ErrorHandlerMiddleware(RequestDelegate next, ILogger<ErrorHandlerMiddleware> logger)
        {
            _next = next;
            this.logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                logger.LogError("Thrown exception!");

                switch (ex)
                {
                    case AppException e:
                        response.StatusCode = (int)HttpStatusCode.BadRequest; 
                        break;
                    default:
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }

                var result = JsonSerializer.Serialize(new {message=ex?.Message});
                await response.WriteAsync(result);
            }
        }
    }
}
