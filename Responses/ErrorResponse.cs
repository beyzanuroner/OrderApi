namespace OrderApi.Responses;

public class ErrorResponse
{
    public bool Success { get; set; }
    public string Message { get; set; } = string.Empty;
    public string? Detail { get; set; }
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
}