// Application Layer - CourseService
using StudentManagementSystem.Application.Dtos.Course.Requests;
using StudentManagementSystem.Application.Dtos.Course.Response;
using StudentManagementSystem.Application.Interfaces;
using StudentManagementSystem.Domain.Entities;
using StudentManagementSystem.Domain.Interfaces;

namespace StudentManagementSystem.Application.Services
{
    public class CourseService(ICourseRepository _courseRepository) : ICourseService
    {
        public async Task<CourseDto> AddCourseAsync(CourseRequestDto course)
        {
            var existingCourse = await _courseRepository.GetCourseByIdAsync(course.Id);
            if (existingCourse is not null)
            {
                throw new InvalidOperationException("Course already exists");
            }

            var newCourse = new Course
            {
                Name = course.Name,
                Code = course.Code,
                Description = course.Description,
                Department = course.Department,
                Units = course.Units,
               
            };

            var createdCourse = await _courseRepository.AddCourseAsync(newCourse);

            return new CourseDto
            {
                Id = createdCourse.Id,
                Name = createdCourse.Name,
                Code = createdCourse.Code,
                Description = createdCourse.Description,
                Department = createdCourse.Department,
                Units = createdCourse.Units
            };
        }

        public async Task<bool> DeleteCourseAsync(int id)
        {
            var course = await _courseRepository.GetCourseByIdAsync(id);
            if (course is null)
            {
                throw new ArgumentException("Course ID not found");
            }

            return await _courseRepository.DeleteCourseAsync(id);
        }

        public async Task<CourseDto> GetCourseByIdAsync(int id)
        {
            if (id <= 0) throw new ArgumentException("Invalid Course ID");

            var course = await _courseRepository.GetCourseByIdAsync(id);
            return new CourseDto
            {
                Id = course.Id,
                Name = course.Name,
                Code = course.Code,
                Description = course.Description,
                Department = course.Department,
                Units = course.Units,
                SubjectCount = course.Subjects.Count
            };
        }

        public async Task<CourseDto> GetCourseByNameAsync(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("Invalid Course name");

            var course = await _courseRepository.GetCourseByNameAsync(name);
            return new CourseDto
            {
                Id = course.Id,
                Name = course.Name,
                Code = course.Code,
                Description = course.Description,
                Department = course.Department,
                Units = course.Units,
                SubjectCount = course.Subjects.Count
            };
        }

        public async Task<ICollection<CourseDto>> GetCoursesAsync()
        {
            var courses = await _courseRepository.GetCoursesAsync();
            return courses.Select(c => new CourseDto
            {
                Id = c.Id,
                Name = c.Name,
                Code = c.Code,
                Description = c.Description,
                Department = c.Department,
                Units = c.Units,
                SubjectCount = c.Subjects.Count
            }).ToList();
        }

        public async Task<CourseDto> UpdateCourseAsync(int id, CourseRequestDto course)
        {
            if (id <= 0) throw new ArgumentException("Invalid Course ID");

            
            var courseEntity = new Course
            {
                
                Name = course.Name,
                Code = course.Code,
                Description = course.Description,
                Department = course.Department,
                Units = course.Units
            };

            var updatedCourse = await _courseRepository.UpdateCourseAsync(id, courseEntity);

            if (updatedCourse is null)
                throw new ArgumentException("Course not found");

            return new CourseDto
            {
                
                Name = updatedCourse.Name,
                Code = updatedCourse.Code,
                Description = updatedCourse.Description,
                Department = updatedCourse.Department,
                Units = updatedCourse.Units
            };
        }
    }
}
