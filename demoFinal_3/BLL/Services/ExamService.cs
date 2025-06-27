using BLL.DTOs;
using BLL.Interfaces;
using DAL.Interface;
using DAL.Repo;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Services
{
    public class ExamService : IExamService
    {
        private readonly IExamRepository _examRepository;
        private readonly IQuestionRepository _questionRepository;
        private readonly IAnswerRepository _answerRepository;

        public ExamService(IExamRepository examRepository = null, 
                          IQuestionRepository questionRepository = null, 
                          IAnswerRepository answerRepository = null)
        {
            _examRepository = examRepository ?? new ExamRepository();
            _questionRepository = questionRepository ?? new QuestionRepository();
            _answerRepository = answerRepository ?? new AnswerRepository();
        }

        public List<ExamDTO> GetAllExams()
        {
            try
            {
                var exams = _examRepository.GetAll();
                return exams.Select(exam => new ExamDTO
                {
                    Id = exam.Id,
                    Title = exam.Title,
                    Description = exam.Description,
                    Duration = exam.Duration,
                    TotalMarks = exam.TotalMarks,
                    TeacherId = exam.TeacherId,
                    CreatedAt = exam.CreatedAt,
                    IsActive = exam.IsActive
                }).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving exams: {ex.Message}");
            }
        }

        public ExamDTO GetExamById(int id)
        {
            try
            {
                var exam = _examRepository.GetById(id);
                if (exam == null)
                    throw new Exception("Exam not found");

                return new ExamDTO
                {
                    Id = exam.Id,
                    Title = exam.Title,
                    Description = exam.Description,
                    Duration = exam.Duration,
                    TotalMarks = exam.TotalMarks,
                    TeacherId = exam.TeacherId,
                    CreatedAt = exam.CreatedAt,
                    IsActive = exam.IsActive
                };
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving exam: {ex.Message}");
            }
        }

        public ExamDTO CreateExam(ExamDTO examDto)
        {
            try
            {
                if (examDto == null)
                    throw new ArgumentNullException(nameof(examDto));

                if (string.IsNullOrWhiteSpace(examDto.Title))
                    throw new ArgumentException("Exam title is required");

                if (examDto.Duration <= 0)
                    throw new ArgumentException("Exam duration must be greater than 0");

                if (examDto.TotalMarks <= 0)
                    throw new ArgumentException("Total marks must be greater than 0");

                var exam = new DAL.Model.Exam
                {
                    Title = examDto.Title,
                    Description = examDto.Description,
                    Duration = examDto.Duration,
                    TotalMarks = examDto.TotalMarks,
                    TeacherId = examDto.TeacherId,
                    CreatedAt = DateTime.Now,
                    IsActive = true
                };

                var createdExam = _examRepository.Create(exam);
                return new ExamDTO
                {
                    Id = createdExam.Id,
                    Title = createdExam.Title,
                    Description = createdExam.Description,
                    Duration = createdExam.Duration,
                    TotalMarks = createdExam.TotalMarks,
                    TeacherId = createdExam.TeacherId,
                    CreatedAt = createdExam.CreatedAt,
                    IsActive = createdExam.IsActive
                };
            }
            catch (Exception ex)
            {
                throw new Exception($"Error creating exam: {ex.Message}");
            }
        }

        public ExamDTO UpdateExam(int id, ExamDTO examDto)
        {
            try
            {
                if (examDto == null)
                    throw new ArgumentNullException(nameof(examDto));

                var existingExam = _examRepository.GetById(id);
                if (existingExam == null)
                    throw new Exception("Exam not found");

                if (string.IsNullOrWhiteSpace(examDto.Title))
                    throw new ArgumentException("Exam title is required");

                existingExam.Title = examDto.Title;
                existingExam.Description = examDto.Description;
                existingExam.Duration = examDto.Duration;
                existingExam.TotalMarks = examDto.TotalMarks;
                existingExam.IsActive = examDto.IsActive;

                var updatedExam = _examRepository.Update(existingExam);
                return new ExamDTO
                {
                    Id = updatedExam.Id,
                    Title = updatedExam.Title,
                    Description = updatedExam.Description,
                    Duration = updatedExam.Duration,
                    TotalMarks = updatedExam.TotalMarks,
                    TeacherId = updatedExam.TeacherId,
                    CreatedAt = updatedExam.CreatedAt,
                    IsActive = updatedExam.IsActive
                };
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating exam: {ex.Message}");
            }
        }

        public bool DeleteExam(int id)
        {
            try
            {
                var exam = _examRepository.GetById(id);
                if (exam == null)
                    throw new Exception("Exam not found");

                return _examRepository.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting exam: {ex.Message}");
            }
        }

        public List<ExamDTO> GetExamsByTeacher(int teacherId)
        {
            try
            {
                var exams = _examRepository.GetAll().Where(e => e.TeacherId == teacherId).ToList();
                return exams.Select(exam => new ExamDTO
                {
                    Id = exam.Id,
                    Title = exam.Title,
                    Description = exam.Description,
                    Duration = exam.Duration,
                    TotalMarks = exam.TotalMarks,
                    TeacherId = exam.TeacherId,
                    CreatedAt = exam.CreatedAt,
                    IsActive = exam.IsActive
                }).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving teacher exams: {ex.Message}");
            }
        }

        public List<ExamDTO> GetActiveExams()
        {
            try
            {
                var exams = _examRepository.GetAll().Where(e => e.IsActive).ToList();
                return exams.Select(exam => new ExamDTO
                {
                    Id = exam.Id,
                    Title = exam.Title,
                    Description = exam.Description,
                    Duration = exam.Duration,
                    TotalMarks = exam.TotalMarks,
                    TeacherId = exam.TeacherId,
                    CreatedAt = exam.CreatedAt,
                    IsActive = exam.IsActive
                }).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving active exams: {ex.Message}");
            }
        }
    }
} 