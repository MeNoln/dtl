using System;
using System.Net;
using System.Runtime.Serialization;

namespace DataLuna.Back.Common.Exceptions
{
    [Serializable]
    public class HttpStatusCodeException : Exception
    {
        public HttpStatusCode StatusCode { get; }

        public HttpStatusCodeException(HttpStatusCode code, string message = "") : base(message)
        {
            StatusCode = code;
        }
    }
}