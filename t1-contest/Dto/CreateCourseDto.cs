using System.ComponentModel.DataAnnotations;

namespace t1_contest.Dto;

public class CreateCourseDto
{
    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; } = null!;
}