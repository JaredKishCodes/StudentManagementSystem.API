
using StudentManagementSystem.Application.Dtos.Subject.Requests;
using StudentManagementSystem.Application.Dtos.Subject.Response;
using StudentManagementSystem.Domain.Entities;

namespace StudentManagementSystem.Application.Interfaces
{
    public interface ISubjectService
    {
        Task<ICollection<SubjectResponseDto>> GetAllSubjectAsync();
        Task<SubjectResponseDto> GetSubjectByIdAsync(int id);
        Task<SubjectResponseDto> UpdateSubjectAsync(int id, SubjectRequestDto subjectReqDto);
        Task<SubjectResponseDto> AddSubjectAsync(SubjectRequestDto subjectReqDto);
        Task<bool> DeleteSubjectAsync(int id);

    }
}
