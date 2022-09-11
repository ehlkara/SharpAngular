using System;
namespace SharpAngular.Shared.Responses
{
    public class ResponseError : Exception
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
    }
}

