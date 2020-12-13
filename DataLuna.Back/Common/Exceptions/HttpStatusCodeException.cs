using System;
using System.Net;
using System.Runtime.Serialization;

namespace DataLuna.Back.Common.Exceptions
{
    [Serializable]
    public class HttpStatusCodeException : Exception
    {
        public HttpStatusCode StatusCode { get; }
        public string Message { get; }

        public HttpStatusCodeException(HttpStatusCode code, string message)
        {
            StatusCode = code;
            Message = message;
        }
    }
}