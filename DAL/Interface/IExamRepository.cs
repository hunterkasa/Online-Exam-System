using DAL.Model;
using System.Collections.Generic;

namespace DAL.Interface
{
    public interface IExamRepository : IRepository<Exam>
    {
        IEnumerable<Exam> GetByTeacherId(int teacherId);
        IEnumerable<Exam> GetByStudentId(int studentId);
    }
}