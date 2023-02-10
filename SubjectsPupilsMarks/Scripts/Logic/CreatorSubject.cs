using SubjectsPupilsMarks.Scripts.Database;
using SubjectsPupilsMarks.Scripts.Database.Models;

namespace SubjectsPupilsMarks.Scripts.Logic {
    public static class CreatorSubject {
        public static void Create(ApplicationContext db, string subject, string description) {
            SubjectModel subjectModel = new SubjectModel {
                Subject = subject,
                Description = description
            };
            db.Subjects.Add(subjectModel);
            db.SaveChanges();
        }
    }
}