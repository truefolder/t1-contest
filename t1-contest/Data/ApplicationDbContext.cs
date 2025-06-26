using Microsoft.EntityFrameworkCore;
using t1_contest.Entities;

namespace t1_contest.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Course> Courses { get; set; }
    public DbSet<Student> Students { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>().HasKey(x => x.Id);
        modelBuilder.Entity<Student>().HasKey(x => x.Id);
        modelBuilder.Entity<Course>().HasMany(x => x.Students)
            .WithOne(x => x.Course)
            .HasForeignKey(x => x.CourseId);
    }
}