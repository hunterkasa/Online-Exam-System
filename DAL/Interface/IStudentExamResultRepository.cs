using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface IStudentExamResultRepository : IRepository<StudentExamResult>
    {
        IEnumerable<StudentExamResult> GetResultsByStudentId(int studentId);
        IEnumerable<StudentExamResult> GetResultsByExamId(int examId);
    }
}
