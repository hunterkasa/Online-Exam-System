using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DAL.Model
{
    public class Context : DbContext
    {
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<StudentExamResult> StudentExamResults { get; set; }
        public DbSet<Token> Tokens { get; set; } // Add Token DbSet

        public Context() : base("name=Context")
        {
        }
    }
}
