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
    public class TeacherRepository : Repository<Teacher>, ITeacherRepository
    {
        public TeacherRepository(DbContext context) : base(context) { }

        public Teacher GetByEmail(string email)
        {
            return _dbSet.FirstOrDefault(t => t.Email.ToLower() == email.ToLower());
        }
    }
}
