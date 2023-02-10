using System.Text.Json.Serialization;

namespace SubjectsPupilsMarks.Scripts.ApplicationInfo {
    public class Information {
        [JsonPropertyName("name")] public string Name { get; } = string.Empty;
        
        [JsonPropertyName("env")] public string Environment { get; } = string.Empty;
        
        [JsonPropertyName("path")] public string Path { get; } = string.Empty;

        public Information(WebApplication app) {
            this.Name = app.Environment.ApplicationName.ToString();
            this.Environment = app.Environment.EnvironmentName.ToString();
            this.Path = app.Environment.ContentRootPath.ToString();
        }
    }
}