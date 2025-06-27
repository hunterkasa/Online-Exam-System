using DAL.Interface;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAL.Repo
{
    public class ExamRepository : IExamRepository
    {
        private readonly DbContext _context;
        public ExamRepository(DbContext context)
        {
            _context = context;
        }
        public void Add(Exam entity)
        {
            _context.Set<Exam>().Add(entity);
            _context.SaveChanges();
        }
        public IEnumerable<Exam> GetAll()
        {
            return _context.Set<Exam>().ToList();
        }
        public Exam GetById(int id)
        {
            return _context.Set<Exam>().Find(id);
        }
        public IEnumerable<Exam> Find(System.Linq.Expressions.Expression<Func<Exam, bool>> predicate)
        {
            return _context.Set<Exam>().Where(predicate).ToList();
        }
        public void Update(Exam entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public void Remove(Exam entity)
        {
            _context.Set<Exam>().Remove(entity);
            _context.SaveChanges();
        }
        public IEnumerable<Exam> GetByTeacherId(int teacherId)
        {
            return _context.Set<Exam>().Where(e => e.TeacherId == teacherId).ToList();
        }
        public IEnumerable<Exam> GetByStudentId(int studentId)
        {
            var examIds = _context.Set<StudentExamResult>() 
                                  .Where(r => r.StudentId == studentId)
                                  .Select(r => r.ExamId)
                                  .Distinct()
                                  .ToList();
            return _context.Set<Exam>().Where(e => examIds.Contains(e.ExamId)).ToList();
        }
    }

}