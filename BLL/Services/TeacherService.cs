using AutoMapper;
using BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL.Services
{
    public class TeacherService
    {
        public IEnumerable<TeacherDTO> GetAllTeachers()
        {   
            var data = DAL.DataAccessFactory.GetTeacherRepository().GetAll();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<DAL.Model.Teacher, TeacherDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<IEnumerable<TeacherDTO>>(data);
            return mapped;
        }

        public TeacherDTO GetTeacherById(int id)
        {
            var teacherRepo = DataAccessFactory.GetTeacherRepository();
            var teacher = teacherRepo.GetById(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<DAL.Model.Teacher, TeacherDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<TeacherDTO>(teacher);
            return mapped;
        }
        public void CreateTeacher(TeacherDTO teacher)
        {
            var teacherRepo = DataAccessFactory.GetTeacherRepository();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<TeacherDTO, DAL.Model.Teacher>();
            });
            var mapper = new Mapper(cfg);
            var entity = mapper.Map<DAL.Model.Teacher>(teacher);
            teacherRepo.Add(entity);
        }
        public void UpdateTeacher(TeacherDTO teacher)
        {
            var teacherRepo = DataAccessFactory.GetTeacherRepository();
            var entity = teacherRepo.GetById(teacher.TeacherId);
            if (entity == null) return;

            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<TeacherDTO, DAL.Model.Teacher>();
            });
            var mapper = new Mapper(cfg);
            mapper.Map(teacher, entity);
            teacherRepo.Update(entity);
        }

        public void DeleteTeacher(int id)
        {
            var teacherRepo = DataAccessFactory.GetTeacherRepository();
            var entity = teacherRepo.GetById(id);
            if (entity != null)
                teacherRepo.Remove(entity);
        }
    }
}
