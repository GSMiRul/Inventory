using Application.Common.RequestResponses;
using System.Net;
using System.Text.Json;

namespace WEBAPI.Middleware
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                var resp = context.Response;
                resp.ContentType = "application/json";
                var responseModel = new RequestResponse<string>()
                {
                    Succeded = false,
                    Message = ex?.Message,
                };
                switch (ex)
                {
                    case Application.Common.Exceptions.ApiException e:
                        resp.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    case Application.Common.Exceptions.ValidationException ve:
                        resp.StatusCode = (int)HttpStatusCode.BadRequest;
                        responseModel.Errors = ve.Errors;
                        break;
                    case KeyNotFoundException e:
                        resp.StatusCode = (int)HttpStatusCode.NotFound;
                        break;
                    default:
                        resp.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }
                var result = JsonSerializer.Serialize(responseModel);
                await resp.WriteAsync(result);
            }
        }
    }
}
