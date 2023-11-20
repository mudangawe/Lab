using System.Net;
using WebAPI.Common.Model;
using WebAPI.Controllers;

namespace WebAPI.MiddleWareServices
{
    public class CustomMiddleware 
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<CustomMiddleware> _logger;
        public CustomMiddleware(RequestDelegate next, ILogger<CustomMiddleware> logger)
        {
            _next = next;
            this._logger = logger;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception : ", ex.Message);
                var response = context.Response;
                response.ContentType = "application/json";
                response.StatusCode = (int) HttpStatusCode.BadRequest;
                var responseModel = new ErrorModel() { IsSuccessful= false, Message = ex.Message };
                await response.WriteAsJsonAsync(responseModel);
            }
        }
    }

       

    public static class ClassWithNoImplementationMiddlewareExtensions
    {
        public static IApplicationBuilder ExceptionHandlingMiddleware( this IApplicationBuilder builder)
        {
            builder.UseMiddleware<CustomMiddleware>();
            return builder;
        }
    }
}
