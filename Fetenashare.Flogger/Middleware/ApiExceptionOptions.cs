using System;
using Microsoft.AspNetCore.Http;

namespace Fetenashare.Flogger.Middleware
{
    public class ApiExceptionOptions
    {       
        public Action<HttpContext, Exception, ApiError> AddResponseDetails { get; set; }        
    }
}
