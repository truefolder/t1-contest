namespace t1_contest.Entities;

public class Course : BaseEntity
{
    public string Name { get; set; } = null!;
    public List<Student> Students { get; set; } = [];
}