

using StudentManagementSystem.Domain.Entities;

namespace StudentManagementSystem.Domain.Interfaces
{
    public interface ICourseRepository
    {
        Task<ICollection<Course>> GetCoursesAsync();
        Task<Course> GetCourseByNameAsync(string name);
        Task<Course> AddCourseAsync(Course course);
        Task<Course> UpdateCourseAsync(int id, Course course);
        Task<bool> DeleteCourseAsync(int id);
        Task<Course> GetCourseByIdAsync(int id);

    }
}
