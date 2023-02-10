using SubjectsPupilsMarks.Scripts.Database;
using SubjectsPupilsMarks.Scripts.Database.Models;

namespace SubjectsPupilsMarks.Scripts.Logic {
    public static class CreatorPupil {
        public static void Create(ApplicationContext db, string nickname, int age) {
            PupilModel pupilModel = new PupilModel {
                Nickname = nickname,
                Age = age
            };
            db.Pupils.Add(pupilModel);
            db.SaveChanges();
        }
    }
}
