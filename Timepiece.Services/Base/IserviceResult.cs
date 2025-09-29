namespace Timepiece.Services.Base
{
    public interface IserviceResult
    {
        int StatusCode { get; set; }
        string? Message { get; set; }
        object? Data { get; set; }
    }
}
