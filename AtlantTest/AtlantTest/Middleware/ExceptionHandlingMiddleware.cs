using AtlantTest.Domain.Exceptions;
using AtlantTest.DTO;
using System.Net;
using System.Text.Json;

namespace AtlantTest.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        RequestDelegate next;
        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            this.next = next;   
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (Exception ex)
            {
               await ErrorHandling(context, ex);
            }
        }

        private Task ErrorHandling(HttpContext context,  Exception ex)
        {
            var code = ex switch
            {
                BadRequestException _ => HttpStatusCode.BadRequest,
                ConflictException _ => HttpStatusCode.Conflict,
                NotFoundException _ => HttpStatusCode.NotFound,
                _ => HttpStatusCode.InternalServerError
            };
            var errors = new List<string>() { ex.Message };
            var result = JsonSerializer.Serialize(ApiResult<string>.Failure(code, errors));
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(result);


        }
    }
}
