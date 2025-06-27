using DAL.Interface;
using DAL.Model;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAL.Repo
{
    public class QuestionRepository : Repository<Question>, IQuestionRepository
    {
        public QuestionRepository(DbContext context) : base(context) { }

        public IEnumerable<Question> GetQuestionsByExamId(int examId)
        {
            return _dbSet.Where(q => q.ExamId == examId).ToList();
        }
    }
}
