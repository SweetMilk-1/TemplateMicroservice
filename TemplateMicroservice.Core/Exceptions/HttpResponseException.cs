using System.Net;

namespace TemplateMicroservice.Core.Exceptions;
/// <summary>
/// Исключение для формирования http - ответа клиенту
/// </summary>
public class HttpResponseException : AppException
{
    /// <summary>
    /// Http код полученного ответа
    /// </summary>
    public HttpStatusCode StatusCode { get; }

    /// <summary>
    /// Объект с дополнительными данными
    /// </summary>
    public object? AdditionalData { get; protected set; }
    public HttpResponseException(HttpStatusCode statusCode, string message, object? additionalData = null) : base(message)
    {
        StatusCode = statusCode;
        AdditionalData = additionalData;
    }
}
