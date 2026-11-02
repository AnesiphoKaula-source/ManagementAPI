using System.Diagnostics;
namespace UserManagementAPI.Middleware;
public class RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger) {
    public async Task InvokeAsync(HttpContext context) {
        var timer = Stopwatch.StartNew();
        try { await next(context); }
        finally { logger.LogInformation("{Method} {Path} => {StatusCode} ({ElapsedMs} ms)", context.Request.Method, context.Request.Path, context.Response.StatusCode, timer.ElapsedMilliseconds); }
    }
}
