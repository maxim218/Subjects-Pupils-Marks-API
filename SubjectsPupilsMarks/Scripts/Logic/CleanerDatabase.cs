using Microsoft.EntityFrameworkCore;
using SubjectsPupilsMarks.Scripts.Database;

namespace SubjectsPupilsMarks.Scripts.Logic {
    public static class CleanerDatabase {
        public static void Clear(ApplicationContext db) {
            db.Subjects.ExecuteDelete();
            db.Pupils.ExecuteDelete();
            db.Marks.ExecuteDelete();
        }
    }
}