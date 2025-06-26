using Microsoft.AspNetCore.Mvc;
using t1_contest.Dto;
using t1_contest.Interfaces;

namespace t1_contest.Controllers;

[ApiController]
[Route("courses")]
public class CourseController(ICourseService courseService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult> GetAllCourses()
    {
        var courses = await courseService.GetAllCourses();
        
        if (!courses.Any())
            return NotFound();
        
        return Ok(courses);
    }

    [HttpPost]
    public async Task<ActionResult> CreateCourse(CreateCourseDto course)
    {
        var courseId = await courseService.CreateCourse(course);
        return Ok(courseId);
    }

    [HttpPost("{id:guid}/students")]
    public async Task<ActionResult> CreateStudent(CreateStudentDto student, [FromRoute] Guid id)
    {
        var studentId = await courseService.CreateStudent(student, id);
        return Ok(studentId);
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> DeleteCourse([FromRoute] Guid id)
    {
        var result = await courseService.DeleteCourse(id);
        
        if (!result)
            return NotFound();
        
        return Ok(result);
    }
}