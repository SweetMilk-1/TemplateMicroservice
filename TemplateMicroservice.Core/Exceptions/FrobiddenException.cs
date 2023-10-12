using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMicroservice.Core.Exceptions
{
    /// <summary>
    /// Исключение Forbidden
    /// </summary>
    public class FrobiddenException : HttpRequestException
    {
        public FrobiddenException(string message, object? additionalData = null) : base(HttpStatusCode.Forbidden, message, additionalData)
        {
        }
    }
}
