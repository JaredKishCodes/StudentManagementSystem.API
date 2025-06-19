
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Domain.Entities;
using StudentManagementSystem.Domain.Interfaces;
using StudentManagementSystem.Infrastructure.Data;

namespace StudentManagementSystem.Infrastructure.Repositories
{
    public class SubjectRepository(AppDbContext _dbContext) : ISubjectRepository
    {
        public async Task<Subject> AddSubjectAsync(Subject subject)
        {
          await _dbContext.Subjects.AddAsync(subject);
          await _dbContext.SaveChangesAsync();

            return await _dbContext.Subjects
          .Include(s => s.Course)
          .FirstOrDefaultAsync(s => s.Id == subject.Id);
        }

        public async Task<bool> DeleteSubjectAsync(int id)
        {
           var result = await _dbContext.Subjects.FindAsync(id);

            if (result != null) 
            { 
                _dbContext.Remove(result);
               await _dbContext.SaveChangesAsync();
                return true;
            }

           return false;
        }

        public async Task<Subject> GetSubjectByIdAsync(int id)
        {
            return await _dbContext.Subjects.Include(x => x.Course).FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<Subject> GetSubjectByTitleAsync(string title)
        {
            return await _dbContext.Subjects.Include(x => x.Course).FirstOrDefaultAsync(x => x.Title == title);
        }

        public async Task<IEnumerable<Subject>> GetSubjectsAsync()
        {
            return await _dbContext.Subjects.Include(u => u.Course).ToListAsync();
                
        }

        public async Task<Subject> UpdateSubjectAsync(int id, Subject subject)
        {
            var existingSubject = await _dbContext.Subjects.FindAsync(id);

            if (existingSubject is null) {
                throw new KeyNotFoundException("Can't find Id from the Database");
            }

            existingSubject.Title = subject.Title;
            existingSubject.Description = subject.Description;
            existingSubject.YearLevel = subject.YearLevel;
            existingSubject.Semester = subject.Semester;
            existingSubject.CourseId = subject.CourseId;

            await _dbContext.SaveChangesAsync();

            return existingSubject;

        }
    }
}
