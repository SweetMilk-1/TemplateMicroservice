using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMicroservice.Core.Exceptions
{
    /// <summary>
    /// Исключение Unauthorized
    /// </summary>
    public class UnauthorizedException : HttpRequestException
    {
        public UnauthorizedException(string message, object? additionalData = null) : base(HttpStatusCode.Unauthorized, message, additionalData)
        {
        }
    }
}
