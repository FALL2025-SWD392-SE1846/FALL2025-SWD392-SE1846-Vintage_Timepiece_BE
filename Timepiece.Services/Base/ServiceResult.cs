using System.Text.Json.Serialization;

namespace Timepiece.Services.Base
{
    internal class ServiceResult : IserviceResult
    {
        public int StatusCode { get; set; }
        public string? Message { get; set; }
        public object? Data { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<string>? Errors { get; set; }
      
        public ServiceResult()
        {
            StatusCode = -1;
            Message = "Action fail";
        }
        public ServiceResult(int status, string message)
        {
            StatusCode = status;
            Message = message;
        }

        public ServiceResult(int status, string message, object data)
        {
            StatusCode = status;
            Message = message;
            Data = data;
        }

        public ServiceResult(int status, string message, List<string> errors)
        {
            StatusCode = status;
            Message = message;
            Errors = errors;
        }
    }
}
