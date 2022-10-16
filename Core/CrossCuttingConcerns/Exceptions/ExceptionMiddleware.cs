using Core.Business.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;


namespace Core.CrossCuttingConcerns.Exceptions
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                await HandleException(context, exception);
            }
        }

        private Task HandleException(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            if (exception.GetType() == typeof(BusinessException))
            {
                return CreateBusinessException(context, exception);
            }
            if(exception.GetType() == typeof(ValidationException))
            {
                return CreateValidationException(context, exception);
            }

            return CreateInternalException(context, exception);
        }

        private Task CreateValidationException(HttpContext context, Exception exception)
        {
            context.Response.StatusCode = Convert.ToInt32(HttpStatusCode.BadRequest);
            ValidationException validationException = exception as ValidationException;
            return context.Response.WriteAsync(new ValidationProblemDetails
            {
                Status = StatusCodes.Status400BadRequest,
                Type = "https://rentacar.com/api/docs/validation",
                Title = "Validation Excepiton",
                Detail = "",
                Instance = " ",
                Errors = validationException.Errors
            }.ToString());
        }

        private Task CreateInternalException(HttpContext context, Exception exception)
        {
            context.Response.StatusCode = Convert.ToInt32(HttpStatusCode.InternalServerError);
            return context.Response.WriteAsync(JsonConvert.SerializeObject(new ProblemDetails
            {
                Status = StatusCodes.Status500InternalServerError,
                Type = "https://rentacar.com/api/docs/internal",
                Title = "Internal Excepiton",
                Detail = exception.Message,
                Instance = " "
            }));
        }

        private Task CreateBusinessException(HttpContext context, Exception exception)
        {
            context.Response.StatusCode = Convert.ToInt32(HttpStatusCode.BadRequest);
            return context.Response.WriteAsync(new BusinessProblemDetails
            {
                Status = StatusCodes.Status400BadRequest,
                Type = "https://rentacar.com/api/docs/business",
                Title = "Business Excepiton",
                Detail = exception.Message,
                Instance = " "
            }.ToString());
        }


    }
}
