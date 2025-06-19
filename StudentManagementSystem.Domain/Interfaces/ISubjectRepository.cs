
using StudentManagementSystem.Domain.Entities;

namespace StudentManagementSystem.Domain.Interfaces
{
    public interface ISubjectRepository
    {
        Task<IEnumerable<Subject>> GetSubjectsAsync();
        Task<Subject> GetSubjectByIdAsync(int id);

        Task<Subject> GetSubjectByTitleAsync(string title);

        Task<Subject> AddSubjectAsync(Subject subject);
        Task<Subject> UpdateSubjectAsync(int id, Subject subject);
        Task<bool> DeleteSubjectAsync(int id);

    }
}
