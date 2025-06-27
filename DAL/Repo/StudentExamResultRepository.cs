using DAL.Interface;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public class StudentExamResultRepository : Repository<StudentExamResult>, IStudentExamResultRepository
    {
        public StudentExamResultRepository(DbContext context) : base(context) { }

        public IEnumerable<StudentExamResult> GetResultsByStudentId(int studentId)
        {
            return _dbSet.Where(r => r.StudentId == studentId).ToList();
        }

        public IEnumerable<StudentExamResult> GetResultsByExamId(int examId)
        {
            return _dbSet.Where(r => r.ExamId == examId).ToList();
        }
    }
}
