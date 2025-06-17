// Application Layer - CourseService
using StudentManagementSystem.Application.Dtos;
using StudentManagementSystem.Application.Interfaces;
using StudentManagementSystem.Domain.Entities;
using StudentManagementSystem.Domain.Interfaces;

namespace StudentManagementSystem.Application.Services
{
    public class CourseService(ICourseRepository _courseRepository) : ICourseService
    {
        public async Task<CourseDto> AddCourseAsync(CourseRequestDto course)
        {
            var existingCourse = await _courseRepository.GetCourseByNameAsync(course.Name);
            if (existingCourse is not null)
            {
                throw new InvalidOperationException("Course already exists");
            }

            var newCourse = new Course
            {
                Name = course.Name,
                Description = course.Description,
                Department = course.Department,
                Units = course.Units
            };

            var createdCourse = await _courseRepository.AddCourseAsync(newCourse);

            return new CourseDto
            {
                Id = createdCourse.Id,
                Name = createdCourse.Name,
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
                Description = course.Description,
                Department = course.Department,
                Units = course.Units
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
                Description = course.Description,
                Department = course.Department,
                Units = course.Units
            };
        }

        public async Task<ICollection<CourseDto>> GetCoursesAsync()
        {
            var courses = await _courseRepository.GetCoursesAsync();
            return courses.Select(c => new CourseDto
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description,
                Department = c.Department,
                Units = c.Units
            }).ToList();
        }

        public async Task<CourseDto> UpdateCourseAsync(int id, CourseRequestDto course)
        {
            if (id <= 0) throw new ArgumentException("Invalid Course ID");

            var courseEntity = new Course
            {
                Id = id,
                Name = course.Name,
                Description = course.Description,
                Department = course.Department,
                Units = course.Units
            };

            var updatedCourse = await _courseRepository.UpdateCourseAsync(id, courseEntity);

            if (updatedCourse is null)
                throw new ArgumentException("Course not found");

            return new CourseDto
            {
                Id = updatedCourse.Id,
                Name = updatedCourse.Name,
                Description = updatedCourse.Description,
                Department = updatedCourse.Department,
                Units = updatedCourse.Units
            };
        }
    }
}
