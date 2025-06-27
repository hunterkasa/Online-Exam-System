using DAL.Interface;
using DAL.Model;
using System;
using System.Data.Entity;
using System.Linq;

namespace DAL.Repo
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly DbContext _context;

        public AuthenticationRepository(DbContext context)
        {
            _context = context;
        }

        public Teacher AuthenticateTeacher(string email, string password)
        {
            return _context.Set<Teacher>().FirstOrDefault(t => 
                t.Email.ToLower() == email.ToLower() && 
                t.Password == password);
        }

        public Student AuthenticateStudent(string email, string password)
        {
            return _context.Set<Student>().FirstOrDefault(s => 
                s.Email.ToLower() == email.ToLower() && 
                s.Password == password);
        }
    }
}