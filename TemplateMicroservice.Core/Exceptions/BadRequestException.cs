using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMicroservice.Core.Exceptions
{
    /// <summary>
    /// Исключение для BadRequest
    /// </summary>
    public class BadRequestException : HttpRequestException
    {
        public BadRequestException(string message, object? additionalData = null) : base(HttpStatusCode.BadRequest, message, additionalData)
        {
        }
    }
}
