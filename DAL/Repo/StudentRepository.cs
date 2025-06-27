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
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        public StudentRepository(DbContext context) : base(context) { }

        public Student GetByEmail(string email)
        {
            return _dbSet.FirstOrDefault(s => s.Email.ToLower() == email.ToLower());
        }
    }
}
