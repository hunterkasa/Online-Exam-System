using BLL.DTOs;
using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface IExamService
    {
        List<ExamDTO> GetAllExams();
        ExamDTO GetExamById(int id);
        ExamDTO CreateExam(ExamDTO examDto);
        ExamDTO UpdateExam(int id, ExamDTO examDto);
        bool DeleteExam(int id);
        List<ExamDTO> GetExamsByTeacher(int teacherId);
        List<ExamDTO> GetActiveExams();
    }
} 