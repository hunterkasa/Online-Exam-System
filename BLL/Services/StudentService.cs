using AutoMapper;
using BLL.DTOs;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class StudentService
    {
        public IEnumerable<StudentDTO> GetAllStudents()
        {
            var data = DataAccessFactory.GetStudentRepository().GetAll();
            var cfg = new MapperConfiguration(c => { c.CreateMap<DAL.Model.Student, StudentDTO>(); });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<IEnumerable<StudentDTO>>(data);
            return mapped;
        }

        public StudentDTO GetStudentById(int id)
        {
            var studentRepo = DataAccessFactory.GetStudentRepository();
            var student = studentRepo.GetById(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<DAL.Model.Student, StudentDTO>();
            });
            var mapper = new Mapper(cfg);
            return mapper.Map<StudentDTO>(student);
        }

        public void CreateStudent(StudentDTO student)
        {
            var studentRepo = DataAccessFactory.GetStudentRepository();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<StudentDTO, DAL.Model.Student>();
            });
            var mapper = new Mapper(cfg);
            var entity = mapper.Map<DAL.Model.Student>(student);
            studentRepo.Add(entity);
        }

        public void UpdateStudent(StudentDTO student)
        {
            var studentRepo = DataAccessFactory.GetStudentRepository();
            var entity = studentRepo.GetById(student.StudentId);
            if (entity == null) return;

            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<StudentDTO, DAL.Model.Student>();
            });
            var mapper = new Mapper(cfg);
            mapper.Map(student, entity);
            studentRepo.Update(entity);
        }

        public void DeleteStudent(int id)
        {
            var studentRepo = DataAccessFactory.GetStudentRepository();
            var entity = studentRepo.GetById(id);
            if (entity != null)
                studentRepo.Remove(entity);
        }
    }
}
