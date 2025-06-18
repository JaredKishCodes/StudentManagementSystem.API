
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Application.Dtos;
using StudentManagementSystem.Domain.Entities;
using StudentManagementSystem.Domain.Interfaces;
using StudentManagementSystem.Infrastructure.Data;

namespace StudentManagementSystem.Infrastructure.Repositories
{
    public class CourseRepository(AppDbContext _dbContext) : ICourseRepository
    {
        public async Task<Course> AddCourseAsync(Course course)
        {
            await _dbContext.Courses.AddAsync(course);
            await _dbContext.SaveChangesAsync();

            return course;
        }

        public async Task<bool> DeleteCourseAsync(int id)
        {
          var course =  await _dbContext.Courses.FindAsync(id);
            if (course is not null)
            {
                _dbContext.Courses.Remove(course);
                await _dbContext.SaveChangesAsync();

                return true;
            }
            

            return false;
        }

        public async Task<Course> GetCourseByCodeAsync(string code)
        {
            return await _dbContext.Courses.FirstOrDefaultAsync(x => x.Code == code);
        }

        public async Task<Course> GetCourseByIdAsync(int id)
        {
            return await _dbContext.Courses.FindAsync(id);
        }

        public async Task<Course> GetCourseByNameAsync(string name)
        {
            return await _dbContext.Courses.FirstOrDefaultAsync(x => x.Name == name);

            
        }

        public async Task<ICollection<Course>> GetCoursesAsync()
        {
            return await _dbContext.Courses.ToListAsync();
        }

        public async Task<Course> UpdateCourseAsync(int id, Course course)
        {
            var result = await _dbContext.Courses.FirstOrDefaultAsync(x => x.Id == id);

            if (result == null)
            {
                throw new Exception("Course Id can not be found");
            }

            result.Name = course.Name;
            result.Code = course.Code;
            result.Description = course.Description;
            result.Department = course.Department;

            await _dbContext.SaveChangesAsync();

            return result;

        }
    }
}
