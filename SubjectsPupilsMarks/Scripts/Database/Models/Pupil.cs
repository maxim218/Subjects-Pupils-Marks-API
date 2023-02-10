using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace SubjectsPupilsMarks.Scripts.Database.Models {
    [Index("Nickname", IsUnique = true, Name = "nickname_unique_index")]
    public class PupilModel {
        public int Id { get; set; } = 0;
        [Required] public string Nickname { get; set; } = string.Empty;
        [Required] public int Age { get; set; } = 0;
    }
}
