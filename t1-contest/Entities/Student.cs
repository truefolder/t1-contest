namespace t1_contest.Entities;

public class Student : BaseEntity
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Patronymic { get; set; } = null!;
    public Guid CourseId { get; set; }
    public Course Course { get; set; } = null!;
}