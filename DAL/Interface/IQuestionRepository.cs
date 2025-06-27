using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface IQuestionRepository : IRepository<Question>
    {
        IEnumerable<Question> GetQuestionsByExamId(int examId);
    }
}
