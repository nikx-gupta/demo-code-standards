using System;
using System.Threading.Tasks;
using Demo.FailFastAndException.Logging;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Demo.FailFastAndException.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly Func<ErrorContext, Task> _exceptionHandler;
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            this._next = next;
            this._exceptionHandler = new Func<ErrorContext, Task>(DisplayException);
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex1)
            {
                if (!context.Response.HasStarted)
                {
                    context.Response.Clear();
                    context.Response.StatusCode = 500;
                    await this._exceptionHandler(new ErrorContext(context, ex1));
                }
            }
        }

        private async Task DisplayException(ErrorContext context)
        {
            var cntxt = context.HttpContext;
            cntxt.Response.ContentType = "application/json";

            // Log and Hide if Unhandled exception
            var logger = cntxt.RequestServices.GetService<ILogService<ExceptionMiddleware>>();
            
            // We can Check for Exception Types and can change output accordingly
            if (context.Exception is InvalidOperationException)
            {
                // Write something else to output or add custom log parameters
            }
            else
            {
                // Log Exception Details
                logger?.LogError(context.Exception, "Unexpected Error Occured");
                // Do not provide Exception Details to consumer
                // Always Provide a TraceId to Consumer so that he can provide it to support for tracking
                await cntxt.Response.WriteAsync($"Unexpected Error Occured. Please Refer logs with CoRelationId: {cntxt.TraceIdentifier}");
            }
        }
    }
}
