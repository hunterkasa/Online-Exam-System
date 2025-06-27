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
    public class ExamController : ApiController
    {
        private readonly ExamService examService;

        public ExamController()
        {
            examService = new ExamService();
        }

        [HttpPost]
        [Route("api/Exam/Create")]
        public HttpResponseMessage Create(ExamDTO examDto)
        {
            try
            {
                var result = examService.Create(examDto);
                if (result != null)
                {
                    return Request.CreateResponse(HttpStatusCode.Created, result);
                }
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Failed to create exam");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("api/Exam/GetAll")]
        public HttpResponseMessage GetAll()
        {
            try
            {
                var exams = examService.GetAll();
                return Request.CreateResponse(HttpStatusCode.OK, exams);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("api/Exam/Get/{id}")]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var exam = examService.GetById(id);
                if (exam != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, exam);
                }
                return Request.CreateResponse(HttpStatusCode.NotFound, "Exam not found");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("api/Exam/GetByTeacher/{teacherId}")]
        public HttpResponseMessage GetByTeacher(int teacherId)
        {
            try
            {
                var exams = examService.GetByTeacher(teacherId);
                return Request.CreateResponse(HttpStatusCode.OK, exams);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("api/Exam/Update/{id}")]
        public HttpResponseMessage Update(int id, ExamDTO examDto)
        {
            try
            {
                examDto.ExamId = id;
                var result = examService.Update(examDto);
                if (result)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Exam updated successfully");
                }
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Failed to update exam");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("api/Exam/Delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var result = examService.Delete(id);
                if (result)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Exam deleted successfully");
                }
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Failed to delete exam");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}