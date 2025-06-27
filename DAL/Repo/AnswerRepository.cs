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
    public class AnswerRepository : Repository<Answer>, IAnswerRepository
    {
        public AnswerRepository(DbContext context) : base(context) { }

        public IEnumerable<Answer> GetAnswersByQuestionId(int questionId)
        {
            return _dbSet.Where(a => a.QuestionId == questionId).ToList();
        }
    }
}
