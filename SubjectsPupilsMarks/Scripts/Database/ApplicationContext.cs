using Microsoft.EntityFrameworkCore;
using SubjectsPupilsMarks.Scripts.Database.Models;

namespace SubjectsPupilsMarks.Scripts.Database {
    public sealed class ApplicationContext : DbContext {
        public DbSet <SubjectModel> Subjects { get; set; } = null!;
        public DbSet <PupilModel> Pupils { get; set; } = null!;
        public DbSet <MarkModel> Marks { get; set; } = null!;
        
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) {
            Database.EnsureCreated();
        }
    }
}