using System.Text.Json.Serialization;

namespace SubjectsPupilsMarks.Scripts.NotFound {
    public class MessageNotFound {
        [JsonPropertyName("msg")] public string Message { get; } = "Error 404 - Not Found";
    }
}
