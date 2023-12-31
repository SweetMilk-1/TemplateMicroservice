﻿using System.Net;

namespace TemplateMicroservice.Core.Exceptions
{
    /// <summary>
    /// Исключение NotFound
    /// </summary>
    public class NotFoundException : HttpErrorWithStatusCodeException
    {
        public NotFoundException(string message, object? additionalData = null) : base(HttpStatusCode.NotFound, message, additionalData)
        {
        }
    }
}
