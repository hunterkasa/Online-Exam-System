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
    [RoutePrefix("api/Result")]
    public class StudentExamResultController : ApiController
    {
        private readonly StudentExamResultService _resultService;

        public StudentExamResultController()
        {
            _resultService = new StudentExamResultService();
        }
        [Logged]
        [HttpPost]
        [Route("{id:int}/submit")]
        public HttpResponseMessage SubmitExam(int id, [FromBody] StudentExamResultDTO resultDto)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            var score = _resultService.SubmitExam(id, resultDto);
            return Request.CreateResponse(HttpStatusCode.OK, new { Score = score, Message = "Exam submitted successfully." });
        }

        [HttpGet]
        [Route("{examId:int}/results")]
        public HttpResponseMessage GetResultsByExamId(int examId)
        {
            var results = _resultService.GetResultsByExamId(examId);
            return Request.CreateResponse(HttpStatusCode.OK, results);
        }

        [HttpGet]
        [Route("student/{studentId:int}/results")]
        public HttpResponseMessage GetResultsByStudentId(int studentId)
        {
            var results = _resultService.GetResultsByStudentId(studentId);
            return Request.CreateResponse(HttpStatusCode.OK, results);
        }
    }
}