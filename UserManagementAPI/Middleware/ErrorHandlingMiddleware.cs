namespace UserManagementAPI.Middleware;
public class ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger) {
    public async Task InvokeAsync(HttpContext context) {
        try { await next(context); }
        catch (Exception ex) {
            logger.LogError(ex, "Unhandled request error");
            if (context.Response.HasStarted) throw;
            context.Response.Clear(); context.Response.StatusCode = 500;
            await context.Response.WriteAsJsonAsync(new { error = "Internal server error." });
        }
    }
}
