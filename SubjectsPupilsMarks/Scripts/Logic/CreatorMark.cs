using SubjectsPupilsMarks.Scripts.Database;
using SubjectsPupilsMarks.Scripts.Database.Models;

namespace SubjectsPupilsMarks.Scripts.Logic {
    public static class CreatorMark {
        public static void Create(ApplicationContext db, string nickname, string subject, int mark) {
            MarkModel obj = new MarkModel {
                Nickname = nickname,
                Subject = subject,
                Mark = mark
            };
            db.Marks.Add(obj);
            db.SaveChanges();
        }
    }
}