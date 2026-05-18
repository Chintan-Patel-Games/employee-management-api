using System.Net;
using System.Text.Json;
using EmployeeManagement.Utility.Responses;
using EmployeeManagement.Utilities;
using Serilog;

namespace EmployeeManagement.Middleware;

public class GlobalExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public GlobalExceptionMiddleware(RequestDelegate next) =>  _next = next;

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            Log.Error(ex, ex.Message);

            await HandleExceptionAsync(context);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context)
    {
        context.Response.ContentType = "Resources.ResponseContentType";

        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        var response = new BaseResponse
        {
            Success = false,
            Message = "Resources.AnErrorOccured"
        };

        var jsonResponse = JsonSerializer.Serialize(response);

        return context.Response.WriteAsync(jsonResponse);
    }
}