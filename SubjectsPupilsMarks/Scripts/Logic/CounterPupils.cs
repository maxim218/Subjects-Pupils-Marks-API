using SubjectsPupilsMarks.Scripts.Database;

namespace SubjectsPupilsMarks.Scripts.Logic {
    public static class CounterPupils {
        public static int GetCount(ApplicationContext db) {
            int n = db.Pupils.Count();
            return n;
        }
    }
}
