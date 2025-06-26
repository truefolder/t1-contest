using System.ComponentModel.DataAnnotations;

namespace t1_contest.Dto;

public class CreateStudentDto
{
    [Required(ErrorMessage = "Name is required")]
    [RegularExpression(
        @"^[А-Яа-яёЁ]+\s+[А-Яа-яёЁ]+\s+[А-Яа-яёЁ]+$",
        ErrorMessage = "Поле должно содержать ровно три слова на русском языке."
    )]
    public string FullName { get; set; } = null!;
}