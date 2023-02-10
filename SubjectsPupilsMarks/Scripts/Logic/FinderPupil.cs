using SubjectsPupilsMarks.Scripts.Database;
using SubjectsPupilsMarks.Scripts.Database.Models;

namespace SubjectsPupilsMarks.Scripts.Logic {
    public static class FinderPupil {
        public static PupilModel ? Find(ApplicationContext db, string nickname) {
            PupilModel ? result = db.Pupils.FirstOrDefault(obj => nickname == obj.Nickname);
            return result;
        }

        public static List<PupilModel> FindAll(ApplicationContext db, string sortType) {
            if ("0" == sortType) {
                List<PupilModel> list = db.Pupils.OrderByDescending(obj => obj.Id).ToList();
                return list;
            } else {
                List<PupilModel> list = db.Pupils.OrderBy(obj => obj.Id).ToList();
                return list;
            }
        }
    }
}