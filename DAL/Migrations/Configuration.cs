namespace DAL.Migrations
{
    using DAL.Model;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.Model.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DAL.Model.Context context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            // Seed 5 teachers
            //context.Teachers.AddOrUpdate(
            //    t => t.Email,
            //    new DAL.Model.Teacher { Name = "Alice Smith", Email = "alice.smith@example.com", Password = "Password123" },
            //    new DAL.Model.Teacher { Name = "Bob Brown", Email = "bob.brown@example.com", Password = "Password123" },
            //    new DAL.Model.Teacher { Name = "Carol White", Email = "carol.white@example.com", Password = "Password123" },
            //    new DAL.Model.Teacher { Name = "David Green", Email = "david.green@example.com", Password = "Password123" },
            //    new DAL.Model.Teacher { Name = "Eve Black", Email = "eve.black@example.com", Password = "Password123" }
            //);

            //// Seed 20 students
            //context.Students.AddOrUpdate(
            //    s => s.Email,
            //    new DAL.Model.Student { Name = "Student 1", Email = "student1@example.com", Password = "Password123" },
            //    new DAL.Model.Student { Name = "Student 2", Email = "student2@example.com", Password = "Password123" },
            //    new DAL.Model.Student { Name = "Student 3", Email = "student3@example.com", Password = "Password123" },
            //    new DAL.Model.Student { Name = "Student 4", Email = "student4@example.com", Password = "Password123" },
            //    new DAL.Model.Student { Name = "Student 5", Email = "student5@example.com", Password = "Password123" },
            //    new DAL.Model.Student { Name = "Student 6", Email = "student6@example.com", Password = "Password123" },
            //    new DAL.Model.Student { Name = "Student 7", Email = "student7@example.com", Password = "Password123" },
            //    new DAL.Model.Student { Name = "Student 8", Email = "student8@example.com", Password = "Password123" },
            //    new DAL.Model.Student { Name = "Student 9", Email = "student9@example.com", Password = "Password123" },
            //    new DAL.Model.Student { Name = "Student 10", Email = "student10@example.com", Password = "Password123" },
            //    new DAL.Model.Student { Name = "Student 11", Email = "student11@example.com", Password = "Password123" },
            //    new DAL.Model.Student { Name = "Student 12", Email = "student12@example.com", Password = "Password123" },
            //    new DAL.Model.Student { Name = "Student 13", Email = "student13@example.com", Password = "Password123" },
            //    new DAL.Model.Student { Name = "Student 14", Email = "student14@example.com", Password = "Password123" },
            //    new DAL.Model.Student { Name = "Student 15", Email = "student15@example.com", Password = "Password123" },
            //    new DAL.Model.Student { Name = "Student 16", Email = "student16@example.com", Password = "Password123" },
            //    new DAL.Model.Student { Name = "Student 17", Email = "student17@example.com", Password = "Password123" },
            //    new DAL.Model.Student { Name = "Student 18", Email = "student18@example.com", Password = "Password123" },
            //    new DAL.Model.Student { Name = "Student 19", Email = "student19@example.com", Password = "Password123" },
            //    new DAL.Model.Student { Name = "Student 20", Email = "student20@example.com", Password = "Password123" }
            //);
            //context.Tokens.AddOrUpdate(
            //    t => t.TokenValue,
            //    new Token { TokenValue = Guid.NewGuid().ToString(), ExpiryDate = DateTime.Now.AddHours(1), UserId = 1, UserType = "Teacher" },
            //    new Token { TokenValue = Guid.NewGuid().ToString(), ExpiryDate = DateTime.Now.AddHours(1), UserId = 2, UserType = "Student" }
            //);
            //context.Tokens.AddOrUpdate(
            //    t => t.TokenValue,
            //    new Token { TokenValue = Guid.NewGuid().ToString(), ExpiryDate = DateTime.Now.AddHours(1), UserId = 1, UserType = "Teacher" },
            //    new Token { TokenValue = Guid.NewGuid().ToString(), ExpiryDate = DateTime.Now.AddHours(1), UserId = 2, UserType = "Student" }
            //);
            //context.Tokens.AddOrUpdate(
            //    t => t.TokenValue,
            //    new Token { TokenValue = Guid.NewGuid().ToString(), ExpiryDate = DateTime.Now.AddHours(1), UserId = 1, UserType = "Teacher" },
            //    new Token { TokenValue = Guid.NewGuid().ToString(), ExpiryDate = DateTime.Now.AddHours(1), UserId = 2, UserType = "Student" }
            //);

            //var teacher = context.Teachers.FirstOrDefault();
            //var student = context.Students.FirstOrDefault();

            //if (teacher == null || student == null)
            //    return; // Can't seed dependent data without teacher/student

            //// Seed Exams
            //context.Exams.AddOrUpdate(
            //    e => e.Title,
            //    new DAL.Model.Exam
            //    {
            //        Title = "Sample Exam 1",
            //        Description = "This is a sample exam.",
            //        StartTime = DateTime.Now.AddDays(1),
            //        EndTime = DateTime.Now.AddDays(1).AddHours(2),
            //        DurationInMinutes = 120,
            //        TeacherId = teacher.TeacherId
            //    }
            //);
            //context.SaveChanges();

            //var exam = context.Exams.FirstOrDefault();

            //// Seed Questions
            //context.Questions.AddOrUpdate(
            //    q => q.QuestionText,
            //    new DAL.Model.Question
            //    {
            //        QuestionText = "What is 2 + 2?",
            //        ExamId = exam.ExamId
            //    }
            //);
            //context.SaveChanges();

            //var question = context.Questions.FirstOrDefault();

            //// Seed Answers
            //context.Answers.AddOrUpdate(
            //    a => a.AnswerText,
            //    new DAL.Model.Answer
            //    {
            //        AnswerText = "4",
            //        IsCorrect = true,
            //        QuestionId = question.QuestionId
            //    },
            //    new DAL.Model.Answer
            //    {
            //        AnswerText = "3",
            //        IsCorrect = false,
            //        QuestionId = question.QuestionId
            //    }
            //);
            //context.SaveChanges();

            //// Seed StudentExamResult
            //context.StudentExamResults.AddOrUpdate(
            //    r => new { r.StudentId, r.ExamId },
            //    new DAL.Model.StudentExamResult
            //    {
            //        StudentId = student.StudentId,
            //        ExamId = exam.ExamId,
            //        Score = 100,
            //        ExamTakenTime = DateTime.Now
            //    }
            //);
            //context.SaveChanges();


            // Seed Teachers
            context.Teachers.AddOrUpdate(
                t => t.Email,
                new Teacher { TeacherId = 1, Name = "Alice Smith", Email = "alice.smith@example.com", Password = "Password123" }
            );
            context.SaveChanges();

            // Seed Students
            context.Students.AddOrUpdate(
                s => s.Email,
                new Student { StudentId = 1, Name = "Student 1", Email = "student1@example.com", Password = "Password123" }
            );
            context.SaveChanges();

            // Seed Exam
            context.Exams.AddOrUpdate(
                e => e.Title,
                new Exam
                {
                    ExamId = 1,
                    Title = "Sample Exam 1",
                    Description = "This is a sample exam.",
                    StartTime = DateTime.Now.AddDays(1),
                    EndTime = DateTime.Now.AddDays(1).AddHours(2),
                    DurationInMinutes = 120,
                    TeacherId = 1,
                    IsActive = true
                }
            );
            context.SaveChanges();

            // Seed StudentExamResult with valid StudentId and ExamId
            context.StudentExamResults.AddOrUpdate(
                r => new { r.StudentId, r.ExamId },
                new StudentExamResult
                {
                    StudentId = 1,
                    ExamId = 1,
                    Score = 95.0m,
                    ExamTakenTime = DateTime.Now
                }
            );
            context.SaveChanges();

        }
    }
}
