using Microsoft.EntityFrameworkCore;
using t1_contest.Data;
using t1_contest.Dto;
using t1_contest.Entities;
using t1_contest.Interfaces;

namespace t1_contest.Services;

public class CourseService(ApplicationDbContext context) : ICourseService
{
    private readonly ApplicationDbContext _context = context;


    public async Task<IEnumerable<CourseResponse>> GetAllCourses()
    {
        var courses = await _context.Courses
            .Include(course => course.Students)
            .Where(course => !course.IsDeleted)
            .ToArrayAsync();
        
        var coursesResponse = courses.Select(x => new CourseResponse
        {
            Id = x.Id, 
            Name = x.Name,
            Students = x.Students.Select(s => new StudentResponse
                { FullName = $"{s.LastName} {s.FirstName} {s.Patronymic}", Id = s.Id}).ToList()
        });
        
        return coursesResponse;
    }

    public async Task<Guid> CreateCourse(CreateCourseDto courseDto)
    {
        var course = new Course { Name = courseDto.Name };
        _context.Courses.Add(course);
        await _context.SaveChangesAsync();
        return course.Id;
    }

    public async Task<Guid> CreateStudent(CreateStudentDto courseDto, Guid courseId)
    {
        var fullName = courseDto.FullName.Split(" ");
        var student = new Student
        {
            LastName = fullName[0],
            FirstName = fullName[1],
            Patronymic = fullName[2],
            CourseId = courseId
        };
        
        _context.Students.Add(student);
        await _context.SaveChangesAsync();
        return student.Id;
    }

    public async Task<bool> DeleteCourse(Guid courseId)
    {
        var course = await _context.Courses.Include(course => course.Students)
            .Where(c => c.Id == courseId && !c.IsDeleted)
            .FirstOrDefaultAsync();

        if (course == null)
            return false;
        
        course.IsDeleted = true;
        course.Students.Select(x => x.IsDeleted = true);
        
        await _context.SaveChangesAsync();
        return true;
    }
}