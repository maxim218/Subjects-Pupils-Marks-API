using System.ComponentModel.DataAnnotations;

namespace SubjectsPupilsMarks.Scripts.Database.Models {
    public class MarkModel {
        public int Id { get; set; } = 0;
        [Required] public string Nickname { get; set; } = string.Empty;
        [Required] public string Subject { get; set; } = string.Empty;
        [Required] public int Mark { get; set; } = 0;
    }
}
