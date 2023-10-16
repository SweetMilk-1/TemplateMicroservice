﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Threading;
using TemplateMicroservice.Core.Exceptions;
using TemplateMicroservice.Core.Models;

namespace TemplateMicroservice.Core.Filters;

/// <summary>
/// Атрибут для обработки исключений
/// </summary>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
{
    private readonly ILogger<CustomExceptionFilterAttribute> _loggingService;
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="loggingService"></param>
    public CustomExceptionFilterAttribute(ILogger<CustomExceptionFilterAttribute> loggingService)
    {
        _loggingService = loggingService;
    }

    private void FluentValidationHandler(ExceptionContext context)
    {
        var ex = context.Exception as HttpErrorWithStatusCodeException;

        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
        context.Result = new JsonResult(
            new ErrorModel
            {
                Message = ex.Message,
                Data = (context.Exception as ValidationException).AdditionalData
            }
        );
    }

    /// <summary>
    /// Возвращает json-объект с определенным статус-кодом при возникновении ошибки
    /// </summary>
    /// <param name="context"></param>
    public override void OnException(ExceptionContext context)
    {
        context.HttpContext.Response.ContentType = "application/json";

        if (context.Exception is ValidationException)
        {
            FluentValidationHandler(context);
            return;
        }

        var code = HttpStatusCode.InternalServerError;
        string message = "";

        if (context.Exception is HttpErrorWithStatusCodeException)
        {
            var ex = context.Exception as HttpErrorWithStatusCodeException;
            code = ex.StatusCode;
            message = ex.Message;
        }

        IActionResult result;
        if (code == HttpStatusCode.InternalServerError)
        {
            result = new JsonResult(new ErrorModel
            {
                Message = context.Exception.InnerException?.Message ?? context.Exception.Message
            });

            string requestBody = "";
        
            var path = context.HttpContext.Request.Path;
            var method = context.HttpContext.Request.Method;
            if (method == "POST" || method == "PUT")
            {
                try
                {
                    context.HttpContext.Request.Body.Seek(0, SeekOrigin.Begin);
                    using (var reader = new StreamReader(context.HttpContext.Request.Body))
                    {
                        requestBody = reader.ReadToEnd();
                    }
                }
                catch (Exception ex)
                {
                    requestBody = $"<Не удалось прочитать тело запроса: {ex.Message}>";
                }
            }
            else
            {
                requestBody = context.HttpContext.Request.QueryString.ToString();
            }

            //Логирование
            _loggingService.LogError($"{DateTime.Now}: {context.Exception.InnerException?.Message ?? context.Exception.Message}\nPath: {path})\nBody:\n{requestBody ?? "null"}");
        }
        else
        {
            var ex = context.Exception as HttpErrorWithStatusCodeException;
            result = new JsonResult(new ErrorModel
            {
                Message = ex.Message,
                Data = ex.AdditionalData
            });
        }

        context.HttpContext.Response.StatusCode = (int)code;
        context.Result = result;
    }
}