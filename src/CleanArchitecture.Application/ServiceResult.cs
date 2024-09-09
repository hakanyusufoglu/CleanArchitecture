using System.Net;
using System.Text.Json.Serialization;

namespace CleanArchitecture.Application
{
    public class ServiceResult<T>
    {
        public T? Data { get; set; }
        public List<string>? ErrorMessage { get; set; }

        [JsonIgnore]
        public bool IsSuccess => ErrorMessage == null || ErrorMessage.Count == 0;
        
        [JsonIgnore]
        public bool IsFailure => !IsSuccess;

        [JsonIgnore]
        public HttpStatusCode Status { get; set; }

        [JsonIgnore]
        public string? UrlAsCreated { get; set; }

        //static factory method
        public static ServiceResult<T> Success(T data, HttpStatusCode status = HttpStatusCode.OK)
        {
            return new () { Data = data, Status = status };
        }
        public static ServiceResult<T> SuccessAsCreated(T data, string urlAsCreated)
        {
            return new() { Data = data, UrlAsCreated = urlAsCreated, Status = HttpStatusCode.Created };
        }
        public static ServiceResult<T> Fail(List<string> errorMessages, HttpStatusCode status = HttpStatusCode.BadRequest)
        {
            return new() { ErrorMessage = errorMessages, Status = HttpStatusCode.BadRequest };
        }
        public static ServiceResult<T> Fail(string errorMessage, HttpStatusCode status = HttpStatusCode.BadRequest)
        {
            return new () { ErrorMessage = [errorMessage], Status = status };
        }
    }

    public class ServiceResult
    {
        public List<string>? ErrorMessage { get; set; }

        [JsonIgnore]
        public bool IsSuccess => ErrorMessage == null || ErrorMessage.Count == 0;

        [JsonIgnore]
        public bool IsFailure => !IsSuccess;

        [JsonIgnore]
        public HttpStatusCode Status { get; set; }

        [JsonIgnore]
        public string? UrlAsCreated { get; set; }

        //static factory method
        public static ServiceResult Success( HttpStatusCode status = HttpStatusCode.OK)
        {
            return new() { Status = status };
        }
        public static ServiceResult Fail(List<string> errorMessages, HttpStatusCode status = HttpStatusCode.BadRequest)
        {
            return new() { ErrorMessage = errorMessages, Status = HttpStatusCode.BadRequest };
        }
        public static ServiceResult Fail(string errorMessage, HttpStatusCode status = HttpStatusCode.BadRequest)
        {
            return new() { ErrorMessage = [errorMessage], Status = status };
        }
    }
}
