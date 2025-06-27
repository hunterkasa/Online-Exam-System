using DAL.Interface;
using DAL.Repo;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using DAL.Model;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {
        private static readonly DbContext context = new Context();

        public static IStudentRepository GetStudentRepository()
        {
            return new StudentRepository(context);
        }

        public static ITeacherRepository GetTeacherRepository()
        {
            return new TeacherRepository(context);
        }

        public static IExamRepository GetExamRepository()
        {
            return new ExamRepository(context);
        }

        public static IQuestionRepository GetQuestionRepository()
        {
            return new QuestionRepository(context);
        }

        public static IAnswerRepository GetAnswerRepository()
        {
            return new AnswerRepository(context);
        }

        public static IStudentExamResultRepository GetStudentExamResultRepository()
        {
            return new StudentExamResultRepository(context);
        }

        public static IAuthenticationRepository GetAuthenticationRepository()
        {
            return new AuthenticationRepository(context);
        }

        public static ITokenRepository GetTokenRepository()
        {
            return new TokenRepository(context);
        }
    }
}
