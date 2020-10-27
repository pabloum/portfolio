using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<ExceptionHandlerMiddleware> logger;

        public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
        {
            this.next = next;
            this.logger = logger;
        }

        public async Task Invoke(HttpContext context /* other dependencies */)
        {
            try
            {
                context.Request.EnableBuffering();
                await next(context);
            }
            catch (InvalidOperationException e)
            {
                await HandleExceptionAsync(context, e, HttpStatusCode.BadRequest);
            }
            catch (Exception e)
            {
                await HandleExceptionAsync(context, e, HttpStatusCode.InternalServerError);
            }
        }

        private async Task<Task> HandleExceptionAsync(HttpContext context, Exception exception, HttpStatusCode statusCode = HttpStatusCode.InternalServerError)
        {
            var request = await FormatRequest(context.Request);
            string result = new ErrorDetails() { Message = exception.Message, StatusCode = (int)statusCode }.ToString();
            context.Response.StatusCode = (int)statusCode;

            //MethodBase method = new StackTrace(exception).GetFrame(0).GetMethod();
            //string methodName = GetMethodName();
            //var paramters = method.GetParameters();

            //var remoteIp = context.Connection.RemoteIpAddress;
            IPHostEntry heserver = Dns.GetHostEntry(Dns.GetHostName());

            var ipAddress = heserver.AddressList.ToList().Where(p => p.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork).FirstOrDefault().ToString();

            //log exception to app insights
            var dictionary = new Dictionary<string, string>
                {
                    { "ipaddress", ipAddress},
                    {"request",request }
                };

            logger.LogError(exception, request);
            return context.Response.WriteAsync(result);
        }

        private async Task<string> FormatRequest(HttpRequest request)
        {
            if (request.ContentLength != null)
            {
                request.Body.Position = 0;
            }

            //This line allows us to set the reader for the request back at the beginning of its stream.
            //request.EnableRewind();

            //We now need to read the request stream.  First, we create a new byte[] with the same length as the request stream...
            var buffer = new byte[Convert.ToInt32(request.ContentLength)];

            //...Then we copy the entire request stream into the new buffer.
            await request.Body.ReadAsync(buffer, 0, buffer.Length).ConfigureAwait(false); ;

            //We convert the byte[] into a string using UTF8 encoding...
            var bodyAsText = Encoding.UTF8.GetString(buffer);


            //..and finally, assign the read body back to the request body, which is allowed because of EnableRewind()
            //request.Body = body;

            return $"{request.Scheme} {request.Host}{request.Path} {request.QueryString} {bodyAsText}";
        }
    }

    public class ErrorDetails
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
