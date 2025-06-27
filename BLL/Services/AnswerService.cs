using System;
using System.Collections.Generic;
using System.Linq;
using BLL.DTOs;
using DAL.Interface;
using DAL.Repo;
using DAL.Model;

namespace BLL.Services
{
    public class AnswerService
    {
        private readonly IAnswerRepository _answerRepository;

        public AnswerService(IAnswerRepository answerRepository = null)
        {
            _answerRepository = answerRepository ?? new AnswerRepository();
        }

        public AnswerDTO CreateAnswer(AnswerDTO answerDto)
        {
            try
            {
                if (answerDto == null)
                    throw new ArgumentNullException(nameof(answerDto));

                if (string.IsNullOrWhiteSpace(answerDto.AnswerText))
                    throw new ArgumentException("Answer text is required");

                var answer = new Answer
                {
                    AnswerText = answerDto.AnswerText,
                    IsCorrect = answerDto.IsCorrect,
                    QuestionId = answerDto.QuestionId
                };

                var createdAnswer = _answerRepository.Create(answer);
                return new AnswerDTO
                {
                    AnswerId = createdAnswer.AnswerId,
                    AnswerText = createdAnswer.AnswerText,
                    IsCorrect = createdAnswer.IsCorrect,
                    QuestionId = createdAnswer.QuestionId
                };
            }
            catch (Exception ex)
            {
                throw new Exception($"Error creating answer: {ex.Message}");
            }
        }

        public List<AnswerDTO> GetAllAnswers()
        {
            try
            {
                var answers = _answerRepository.GetAll();
                return answers.Select(answer => new AnswerDTO
                {
                    AnswerId = answer.AnswerId,
                    AnswerText = answer.AnswerText,
                    IsCorrect = answer.IsCorrect,
                    QuestionId = answer.QuestionId
                }).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving answers: {ex.Message}");
            }
        }

        public AnswerDTO GetAnswerById(int id)
        {
            try
            {
                var answer = _answerRepository.GetById(id);
                if (answer == null)
                    throw new Exception("Answer not found");

                return new AnswerDTO
                {
                    AnswerId = answer.AnswerId,
                    AnswerText = answer.AnswerText,
                    IsCorrect = answer.IsCorrect,
                    QuestionId = answer.QuestionId
                };
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving answer: {ex.Message}");
            }
        }

        public List<AnswerDTO> GetAnswersByQuestionId(int questionId)
        {
            try
            {
                var answers = _answerRepository.GetAll().Where(a => a.QuestionId == questionId).ToList();
                return answers.Select(answer => new AnswerDTO
                {
                    AnswerId = answer.AnswerId,
                    AnswerText = answer.AnswerText,
                    IsCorrect = answer.IsCorrect,
                    QuestionId = answer.QuestionId
                }).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving answers for question: {ex.Message}");
            }
        }

        public AnswerDTO UpdateAnswer(int id, AnswerDTO answerDto)
        {
            try
            {
                if (answerDto == null)
                    throw new ArgumentNullException(nameof(answerDto));

                var existingAnswer = _answerRepository.GetById(id);
                if (existingAnswer == null)
                    throw new Exception("Answer not found");

                if (string.IsNullOrWhiteSpace(answerDto.AnswerText))
                    throw new ArgumentException("Answer text is required");

                existingAnswer.AnswerText = answerDto.AnswerText;
                existingAnswer.IsCorrect = answerDto.IsCorrect;
                existingAnswer.QuestionId = answerDto.QuestionId;

                var updatedAnswer = _answerRepository.Update(existingAnswer);
                return new AnswerDTO
                {
                    AnswerId = updatedAnswer.AnswerId,
                    AnswerText = updatedAnswer.AnswerText,
                    IsCorrect = updatedAnswer.IsCorrect,
                    QuestionId = updatedAnswer.QuestionId
                };
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating answer: {ex.Message}");
            }
        }

        public bool DeleteAnswer(int id)
        {
            try
            {
                var answer = _answerRepository.GetById(id);
                if (answer == null)
                    throw new Exception("Answer not found");

                return _answerRepository.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting answer: {ex.Message}");
            }
        }

        public List<AnswerDTO> GetCorrectAnswersByQuestionId(int questionId)
        {
            try
            {
                var answers = _answerRepository.GetAll()
                    .Where(a => a.QuestionId == questionId && a.IsCorrect)
                    .ToList();
                
                return answers.Select(answer => new AnswerDTO
                {
                    AnswerId = answer.AnswerId,
                    AnswerText = answer.AnswerText,
                    IsCorrect = answer.IsCorrect,
                    QuestionId = answer.QuestionId
                }).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving correct answers: {ex.Message}");
            }
        }
    }
} 