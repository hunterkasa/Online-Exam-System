using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.Model;

namespace BLL.Services
{
    public class QuestionService
    {
        public void CreateQuestion(QuestionDTO questionDto)
        {
            var questionRepo = DataAccessFactory.GetQuestionRepository();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<QuestionDTO, Question>();
            });
            var mapper = new Mapper(cfg);
            var entity = mapper.Map<Question>(questionDto);
            questionRepo.Add(entity);
        }

        public IEnumerable<QuestionDTO> GetQuestionsByExamId(int examId)
        {
            var questionRepo = DataAccessFactory.GetQuestionRepository();
            var data = questionRepo.GetQuestionsByExamId(examId);

            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Question, QuestionDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<IEnumerable<QuestionDTO>>(data);
            return mapped;
        }
        public QuestionDTO GetQuestionById(int id)
        {
            var questionRepo = DataAccessFactory.GetQuestionRepository();
            var question = questionRepo.GetById(id);
            if (question == null) return null;
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Question, QuestionDTO>();
            });
            var mapper = new Mapper(cfg);
            return mapper.Map<QuestionDTO>(question);
        }

        public void UpdateQuestion(QuestionDTO questionDto)
        {
            var questionRepo = DataAccessFactory.GetQuestionRepository();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<QuestionDTO, Question>();
            });
            var mapper = new Mapper(cfg);
            var entity = mapper.Map<Question>(questionDto);
            questionRepo.Update(entity);
        }

        public void DeleteQuestion(int id)
        {
            var questionRepo = DataAccessFactory.GetQuestionRepository();
            var question = questionRepo.GetById(id);
            if (question != null)
            {
                questionRepo.Remove(question);
            }
        }
    }
}
