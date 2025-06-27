using BLL.Interfaces;
using BLL.Services;
using DAL.Interface;
using DAL.Repo;

namespace BLL
{
    public static class ServiceFactory
    {
        public static IExamService CreateExamService()
        {
            IExamRepository examRepo = new ExamRepository();
            IQuestionRepository questionRepo = new QuestionRepository();
            IAnswerRepository answerRepo = new AnswerRepository();
            
            return new ExamService(examRepo, questionRepo, answerRepo);
        }

        public static IStudentService CreateStudentService()
        {
            IStudentRepository studentRepo = new StudentRepository();
            return new StudentService(studentRepo);
        }

        public static ITeacherService CreateTeacherService()
        {
            ITeacherRepository teacherRepo = new TeacherRepository();
            return new TeacherService(teacherRepo);
        }

        public static IAuthenticationService CreateAuthenticationService()
        {
            IAuthenticationRepository authRepo = new AuthenticationRepository();
            return new AuthenticationService(authRepo);
        }
    }
} 