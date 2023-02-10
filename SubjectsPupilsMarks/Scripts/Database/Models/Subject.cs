using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace SubjectsPupilsMarks.Scripts.Database.Models {
    [Index("Subject", IsUnique = true, Name = "subject_unique_index")]
    public class SubjectModel {
        public int Id { get; set; } = 0;
        [Required] public string Subject { get; set; } = string.Empty;
        [Required] public string Description { get; set; } = string.Empty;
    }
}
