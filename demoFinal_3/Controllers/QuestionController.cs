using BLL.DTOs;
using BLL.Services;
using demoFinal_3.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace demoFinal_3.Controllers
{
    [RoutePrefix("api/question")]
    public class QuestionController : ApiController
    {
        private readonly QuestionService _questionService;

        public QuestionController()
        {
            _questionService = new QuestionService();
        }
        [Logged]
        [HttpPost]
        [Route("")]
        public HttpResponseMessage CreateQuestion([FromBody] QuestionDTO questionDto)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            _questionService.CreateQuestion(questionDto);
            return Request.CreateResponse(HttpStatusCode.Created, "Question created successfully.");
        }

        [HttpGet]
        [Route("exam/{examId:int}")]
        public HttpResponseMessage GetQuestionsByExamId(int examId)
        {
            var questions = _questionService.GetQuestionsByExamId(examId);
            return Request.CreateResponse(HttpStatusCode.OK, questions);
        }

        [HttpGet]
        [Route("{id:int}")]
        public HttpResponseMessage GetQuestionById(int id)
        {
            var question = _questionService.GetQuestionById(id);
            if (question == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Question not found.");
            }

            return Request.CreateResponse(HttpStatusCode.OK, question);
        }
        [Logged]
        [HttpPut]
        [Route("{id:int}")]
        public HttpResponseMessage UpdateQuestion(int id, [FromBody] QuestionDTO questionDto)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            questionDto.QuestionId = id;
            _questionService.UpdateQuestion(questionDto);
            return Request.CreateResponse(HttpStatusCode.OK, "Question updated successfully.");
        }
        [Logged]
        [HttpDelete]
        [Route("{id:int}")]
        public HttpResponseMessage DeleteQuestion(int id)
        {
            _questionService.DeleteQuestion(id);
            return Request.CreateResponse(HttpStatusCode.OK, "Question deleted successfully.");
        }
    }
}
