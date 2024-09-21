using Microsoft.EntityFrameworkCore;
using Repository.AdditionalHelper;
using System.Net;
using System.Text.Json;

namespace StudentsDescriptionWebPage.API.Middleware;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (DbUpdateException ex) when (ex.InnerException != null && ex.InnerException.Message.StartsWith("23503"))
        {
            // Error code 23503 - db update or delete error (FK error)
            await HandleExceptionAsync(httpContext, Constants.ObjectIsUsedByEntity, GetStatusCode(ex));
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(httpContext, ex.Message, GetStatusCode(ex));
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, string message,
        HttpStatusCode httpStatusCode = HttpStatusCode.InternalServerError)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)httpStatusCode;

        await context.Response.WriteAsJsonAsync(new ErrorDetails
        {
            StatusCode = context.Response.StatusCode,
            Message = message
        },
            new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            });
    }

    private HttpStatusCode GetStatusCode(Exception exception)
    {
        return exception.Message switch
        {
            Constants.CardAlreadyExist => HttpStatusCode.Conflict,// this always return default value as it can't resolve '{0}' in constant automatically
            Constants.NotFoundEntity => HttpStatusCode.NotFound, //same issue
            Constants.ObjectIsUsedByEntity => HttpStatusCode.Conflict, 
            _ => HttpStatusCode.InternalServerError
        };
    }
}
