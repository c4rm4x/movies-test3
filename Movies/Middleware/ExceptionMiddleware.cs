using FluentValidation;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Middleware
{

    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ValidationException ex)
            {
                await WriteResponseAsync(context, StatusCodes.Status400BadRequest, ex.Errors.Select(_ => new
                {
                    _.PropertyName,
                    _.ErrorMessage
                }));
            }
            catch (Exception ex)
            {
                await WriteResponseAsync(context, StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        private static Task WriteResponseAsync(HttpContext context, int statusCode, object content)
        {
            context.Response.StatusCode = statusCode;
            context.Response.ContentType = "application/json";

            return context.Response.WriteAsync(content as string ?? JsonConvert.SerializeObject(content, new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                }
            }));
        }
    }
}
