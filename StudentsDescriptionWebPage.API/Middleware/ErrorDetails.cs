using System.Text.Json;

namespace StudentsDescriptionWebPage.API.Middleware;

public class ErrorDetails
{
    public int StatusCode { get; set; }

    public string Message { get; set; } = string.Empty;

    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}
