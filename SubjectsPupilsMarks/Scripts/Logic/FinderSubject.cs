using SubjectsPupilsMarks.Scripts.Database;
using SubjectsPupilsMarks.Scripts.Database.Models;

namespace SubjectsPupilsMarks.Scripts.Logic {
    public static class FinderSubject {
        public static SubjectModel ? Find(ApplicationContext db, string subject) {
            SubjectModel ? result = db.Subjects.FirstOrDefault(obj => subject == obj.Subject);
            return result;
        }

        public static List<SubjectModel> FindAll(ApplicationContext db, string sortType) {
            if ("0" == sortType) {
                List <SubjectModel> list = db.Subjects.OrderByDescending(obj => obj.Id).ToList();
                return list;
            } else {
                List <SubjectModel> list = db.Subjects.OrderBy(obj => obj.Id).ToList();
                return list;
            }
        }
    }
}
