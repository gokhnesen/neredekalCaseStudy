using Microsoft.AspNetCore.Http;
using Serilog;
using System.Net.Http;
using System.Threading.Tasks;

namespace neredekalCaseStudy.Infrastructure.Logging
{
    public class SerilogLoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public SerilogLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var request = context.Request;

            Log.Information("Request: {Method} {Url} from {IpAddress}", request.Method, request.Path, context.Connection.RemoteIpAddress);

            await _next(context);

            Log.Information("Response: {StatusCode} for {Method} {Url}", context.Response.StatusCode, request.Method, request.Path);
        }
    }
}
