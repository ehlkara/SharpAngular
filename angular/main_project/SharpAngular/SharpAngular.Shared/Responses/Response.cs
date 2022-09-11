using System;
using System.Text.Json.Serialization;

namespace SharpAngular.Shared.Responses
{
    public class Response<T>
    {
        public T? Result { get; set; }

        [JsonIgnore]
        public int StatusCode { get; set; }

        public ResponseError Error { get; set; }

        public bool HasError { get { return Error != null; } }

        public static async Task<Response<T>> Run(T data, int statusCode)
        {
            return await Task.FromResult(new Response<T> { Result = data, StatusCode = statusCode });
        }
        public static async Task<Response<T>> Catch(ResponseError error, int? errorCode = null)
        {
            return await Task.FromResult(new Response<T> { Error = error, StatusCode = (errorCode.HasValue) ? errorCode.Value : error.StatusCode });
        }
    }
}

