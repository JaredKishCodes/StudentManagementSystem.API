
using StudentManagementSystem.Application.Dtos.Subject.Requests;
using StudentManagementSystem.Application.Dtos.Subject.Response;
using StudentManagementSystem.Application.Interfaces;
using StudentManagementSystem.Domain.Entities;
using StudentManagementSystem.Domain.Interfaces;

namespace StudentManagementSystem.Application.Services
{
    public class SubjectService(ISubjectRepository _subjectRepository, ICourseRepository _courseRepository) : ISubjectService
    {
        public async Task<SubjectResponseDto> AddSubjectAsync( SubjectRequestDto subjectReqDto)
        {
            var subjectExist = await _subjectRepository.GetSubjectByTitleAsync(subjectReqDto.Title);
            if (subjectExist is not null)
            {
                throw new Exception("Subject already exist");
            }

            var course = await _courseRepository.GetCourseByCodeAsync(subjectReqDto.CourseCode);
            if (course is null)
            {
                throw new KeyNotFoundException($"Course with code '{subjectReqDto.CourseCode}' not found");
            }


            var subject = new Subject
            {
                Title = subjectReqDto.Title,
                Description = subjectReqDto.Description,
                YearLevel = subjectReqDto.YearLevel,
                Semester = subjectReqDto.Semester,
                CourseId = course.Id,

            };

            var createdSubject= await _subjectRepository.AddSubjectAsync(subject);

            return new SubjectResponseDto
            {
                Id = createdSubject.Id,
                Title = createdSubject.Title,
                Description = createdSubject.Description,
                YearLevel = createdSubject.YearLevel,
                Semester = createdSubject.Semester,
                CourseCode = createdSubject.Course.Code,
            };

        }

        public async Task<bool> DeleteSubjectAsync(int id)
        {
            if (id <= 0) throw new KeyNotFoundException("Subject ID can not be found"); 
            var exist = await _subjectRepository.GetSubjectByIdAsync(id);

            if(exist  == null)
            {
                throw new KeyNotFoundException("Subject not found");
            }

           return await _subjectRepository.DeleteSubjectAsync(id);
            

        }

        public async Task<ICollection<SubjectResponseDto>> GetAllSubjectAsync()
        {
            var subjects = await _subjectRepository.GetSubjectsAsync();

            if (!subjects.Any())
            {
                throw new Exception("No subjects found.");
            }

            return subjects.Select(subjects => new SubjectResponseDto
            {
                Id = subjects.Id,
                Title = subjects.Title,
                Description = subjects.Description,
                YearLevel = subjects.YearLevel,
                Semester = subjects.Semester,
                CourseCode = subjects.Course.Code,

            }).ToList();
        }

        public async Task<SubjectResponseDto> GetSubjectByIdAsync(int id)
        {
            var subjects = await _subjectRepository.GetSubjectByIdAsync(id);
            if (subjects is null) throw new ArgumentException("Subject ID can't be found");

            

            return new SubjectResponseDto
            {
                Id = subjects.Id,
                Title = subjects.Title,
                Description = subjects.Description,
                YearLevel = subjects.YearLevel,
                Semester = subjects.Semester,
                CourseCode = subjects.Course.Code
            };
        }

        public async Task<SubjectResponseDto> UpdateSubjectAsync(int id, SubjectRequestDto subjectReqDto)
        {
            var existingSubject = await _subjectRepository.GetSubjectByIdAsync(id);
            if(existingSubject is null) throw new ArgumentException("Subject ID can't be found");

            var course = await _courseRepository.GetCourseByCodeAsync(subjectReqDto.CourseCode);
            if (course is null) throw new KeyNotFoundException($"Course with code '{subjectReqDto.CourseCode}' not found.");

            existingSubject.Title = subjectReqDto.Title;
            existingSubject.Description = subjectReqDto.Description;
            existingSubject.YearLevel = subjectReqDto.YearLevel;
            existingSubject.Semester = subjectReqDto.Semester;
            existingSubject.CourseId = course.Id;

            var result = await _subjectRepository.UpdateSubjectAsync(existingSubject.Id, existingSubject);

            return new SubjectResponseDto
            {
                Id = result.Id,
                Title = result.Title,
                Description = result.Description,
                YearLevel = result.YearLevel,
                Semester = result.Semester,
                CourseCode = result.Course.Code
            };
        }
    }
}
