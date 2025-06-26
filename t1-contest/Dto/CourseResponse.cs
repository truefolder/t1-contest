namespace t1_contest.Dto;

public class CourseResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public List<StudentResponse> Students { get; set; } = [];
}