using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMicroservice.Core.Exceptions;

/// <summary>
/// Исключение при http - запросе к внешним сервисам
/// </summary>
public class HttpRequestException:AppException
{
    /// <summary>
    /// Http код полученного ответа
    /// </summary>
    public HttpStatusCode StatusCode { get; }

    /// <summary>
    /// Объект с дополнительными данными
    /// </summary>
    public object? AdditionalData { get; protected set; }

    /// <param name="httpCode">Http-код</param>
    /// <param name="message">Сообщение</param>
    /// <param name="additionalData">Доп. данные</param>
    public HttpRequestException(HttpStatusCode httpCode, string message, object? additionalData = null):base(message)
    {
        StatusCode = httpCode;
        AdditionalData = additionalData;
    }
}
