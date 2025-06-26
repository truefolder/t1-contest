using t1_contest.Dto;
using t1_contest.Entities;

namespace t1_contest.Interfaces;

public interface ICourseService
{
    Task<IEnumerable<CourseResponse>> GetAllCourses();
    
    Task<Guid> CreateCourse(CreateCourseDto courseDto);
    
    Task<Guid> CreateStudent(CreateStudentDto courseDto, Guid courseId);
    
    Task<bool> DeleteCourse(Guid courseId);
}