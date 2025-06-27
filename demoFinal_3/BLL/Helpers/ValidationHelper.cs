using BLL.DTOs;
using System;

namespace BLL.Helpers
{
    public static class ValidationHelper
    {
        public static void ValidateExam(ExamDTO examDto)
        {
            if (examDto == null)
                throw new ArgumentNullException(nameof(examDto));

            if (string.IsNullOrWhiteSpace(examDto.Title))
                throw new ArgumentException("Exam title is required");

            if (examDto.Duration <= 0)
                throw new ArgumentException("Exam duration must be greater than 0");

            if (examDto.TotalMarks <= 0)
                throw new ArgumentException("Total marks must be greater than 0");

            if (examDto.TeacherId <= 0)
                throw new ArgumentException("Valid teacher ID is required");
        }

        public static void ValidateTeacher(TeacherDTO teacherDto)
        {
            if (teacherDto == null)
                throw new ArgumentNullException(nameof(teacherDto));

            if (string.IsNullOrWhiteSpace(teacherDto.Name))
                throw new ArgumentException("Teacher name is required");

            if (string.IsNullOrWhiteSpace(teacherDto.Email))
                throw new ArgumentException("Teacher email is required");
        }
    }
} 