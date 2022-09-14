using System;
using System.Text.Json.Serialization;

namespace SharpAngular.Shared.Responses
{
    public class Response<T>
    {
        public T? Data { get; set; }

        [JsonIgnore]
        public int StatusCode { get; set; }


        public List<string>? Errors { get; set; }

        public ResponseError Error { get; set; }

        public static Response<T> Success(int statusCode, T data)
        {
            return new Response<T> { StatusCode = statusCode, Data = data };
        }

        public static async Task<Response<T>> SuccessAsync(int statusCode, T data)
        {
            return await Task.FromResult(new Response<T> { StatusCode = statusCode, Data = data });
        }
        public static Response<T> Fail(ResponseError error, int? statusCode = null)
        {
            return new Response<T> { StatusCode = (statusCode.HasValue) ? statusCode.Value : error.StatusCode, Error = error };
        }

        public static async Task<Response<T>> FailAsync(ResponseError error, int? statusCode = null)
        {
            return await Task.FromResult(new Response<T> { StatusCode = (statusCode.HasValue) ? statusCode.Value : error.StatusCode, Error = error });
        }
    }
}

