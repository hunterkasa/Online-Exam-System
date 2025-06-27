using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL.DTOs;
using BLL.Services;
using System.Web.Http.Cors;

namespace demoFinal_3.Controllers
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/answer")]
    public class AnswerController : ApiController
    {
        private readonly AnswerService _answerService;

        public AnswerController()
        {
            _answerService = new AnswerService();
        }

        [HttpPost]
        [Route("")]
        public HttpResponseMessage CreateAnswer([FromBody] AnswerDTO answerDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }

                var result = _answerService.CreateAnswer(answerDto);
                return Request.CreateResponse(HttpStatusCode.Created, result);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("")]
        public HttpResponseMessage GetAllAnswers()
        {
            try
            {
                var answers = _answerService.GetAllAnswers();
                return Request.CreateResponse(HttpStatusCode.OK, answers);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("{id:int}")]
        public HttpResponseMessage GetAnswerById(int id)
        {
            try
            {
                var answer = _answerService.GetAnswerById(id);
                return Request.CreateResponse(HttpStatusCode.OK, answer);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("question/{questionId:int}")]
        public HttpResponseMessage GetAnswersByQuestionId(int questionId)
        {
            try
            {
                var answers = _answerService.GetAnswersByQuestionId(questionId);
                return Request.CreateResponse(HttpStatusCode.OK, answers);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("question/{questionId:int}/correct")]
        public HttpResponseMessage GetCorrectAnswersByQuestionId(int questionId)
        {
            try
            {
                var answers = _answerService.GetCorrectAnswersByQuestionId(questionId);
                return Request.CreateResponse(HttpStatusCode.OK, answers);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        [Route("{id:int}")]
        public HttpResponseMessage UpdateAnswer(int id, [FromBody] AnswerDTO answerDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }

                var result = _answerService.UpdateAnswer(id, answerDto);
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        public HttpResponseMessage DeleteAnswer(int id)
        {
            try
            {
                var result = _answerService.DeleteAnswer(id);
                if (result)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Answer deleted successfully");
                }
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Failed to delete answer");
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
} 