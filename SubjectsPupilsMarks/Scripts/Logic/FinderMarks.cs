using SubjectsPupilsMarks.Scripts.Database;
using SubjectsPupilsMarks.Scripts.Database.Models;

namespace SubjectsPupilsMarks.Scripts.Logic {
    public static class FinderMarks {
        public static List<MarkModel> FindMarks(ApplicationContext db, string nickname, string subject, string sortType) {
            IQueryable<MarkModel> query = db.Marks
                .Where(obj => nickname == obj.Nickname)
                .Where(obj => subject == obj.Subject);
            if ("0" == sortType) {
                var list = query.OrderByDescending(obj => obj.Id).ToList();
                return list;
            } else {
                var list = query.OrderBy(obj => obj.Id).ToList();
                return list;
            }
        }
    }
}