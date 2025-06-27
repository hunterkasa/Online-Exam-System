using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.Model;

namespace BLL.Services
{
    public class StudentExamResultService
    {
        public decimal SubmitExam(int studentId, StudentExamResultDTO resultDto)
        {
            var resultRepo = DataAccessFactory.GetStudentExamResultRepository();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<StudentExamResultDTO, StudentExamResult>();
            });
            var mapper = new Mapper(cfg);
            var entity = mapper.Map<StudentExamResult>(resultDto);
            entity.StudentId = studentId;

            resultRepo.Add(entity);
            return entity.Score;
        }

        public IEnumerable<StudentExamResultDTO> GetResultsByStudentId(int studentId)
        {
            var resultRepo = DataAccessFactory.GetStudentExamResultRepository();
            var data = resultRepo.GetResultsByStudentId(studentId);

            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<StudentExamResult, StudentExamResultDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<IEnumerable<StudentExamResultDTO>>(data);
            return mapped;
        }

        public IEnumerable<StudentExamResultDTO> GetResultsByExamId(int examId)
        {
            var resultRepo = DataAccessFactory.GetStudentExamResultRepository();
            var data = resultRepo.GetResultsByExamId(examId);

            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<StudentExamResult, StudentExamResultDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<IEnumerable<StudentExamResultDTO>>(data);
            return mapped;
        }
    }
}
