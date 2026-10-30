using System.Diagnostics;

namespace _02.Middlewares
{
    public class RequestTimingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestTimingMiddleware> _logger;

        public RequestTimingMiddleware(RequestDelegate next, ILogger<RequestTimingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var sw = Stopwatch.StartNew();
            _logger.LogInformation("➡️ Запит: {Method} {Path}", context.Request.Method, context.Request.Path);

            await _next(context);

            sw.Stop();
            _logger.LogInformation("⬅️ Відповідь: {StatusCode} за {Elapsed} мс",
                context.Response.StatusCode, sw.ElapsedMilliseconds);
        }
    }
}