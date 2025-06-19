using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Application.Dtos.Student.Requests
{
    public class CourseSummaryDto
    {
        public string Name { get; set; } = string.Empty;
        public int SubjectCount { get; set; }
    }
}
