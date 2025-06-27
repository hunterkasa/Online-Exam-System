using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.Model;

namespace BLL.Services
{
    public class ExamService
    {
        public ExamDTO Create(ExamDTO examDto)
        {
            var examRepo = DataAccessFactory.GetExamRepository();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<ExamDTO, Exam>();
                c.CreateMap<Exam, ExamDTO>();
            });
            var mapper = new Mapper(cfg);
            var entity = mapper.Map<Exam>(examDto);

            examRepo.Add(entity);

            var resultDto = mapper.Map<ExamDTO>(entity);
            return resultDto;
        }

        public IEnumerable<ExamDTO> GetAll()
        {
            var examRepo = DataAccessFactory.GetExamRepository().GetAll();

            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Exam, ExamDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<IEnumerable<ExamDTO>>(examRepo);
            return mapped;
        }

        public ExamDTO GetById(int id)
        {
            var examRepo = DataAccessFactory.GetExamRepository();
            var exam = examRepo.GetById(id);
            if (exam == null) return null;

            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Exam, ExamDTO>();
            });
            var mapper = new Mapper(cfg);
            return mapper.Map<ExamDTO>(exam);
        }

        public IEnumerable<ExamDTO> GetByTeacher(int teacherId)
        {
            var examRepo = DataAccessFactory.GetExamRepository();
            var data = examRepo.GetByTeacherId(teacherId);

            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Exam, ExamDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<IEnumerable<ExamDTO>>(data);
            return mapped;
        }

        public bool Update(ExamDTO examDto)
        {
            var examRepo = DataAccessFactory.GetExamRepository();
            var existing = examRepo.GetById(examDto.ExamId);
            if (existing == null) return false;

            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<ExamDTO, Exam>();
            });
            var mapper = new Mapper(cfg);
            mapper.Map(examDto, existing);

            examRepo.Update(existing);
            return true;
        }

        public bool Delete(int id)
        {
            var examRepo = DataAccessFactory.GetExamRepository();
            var exam = examRepo.GetById(id);
            if (exam == null) return false;

            examRepo.Remove(exam);
            return true;
        }
    }
}