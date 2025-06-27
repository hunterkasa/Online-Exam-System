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
    [RoutePrefix("api/student")]
    public class StudentController : ApiController
    {
        private readonly StudentService _studentService;

        public StudentController()
        {
            _studentService = new StudentService();
        }

        [HttpPost]
        [Route("")]
        public HttpResponseMessage CreateStudent([FromBody] StudentDTO studentDto)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            _studentService.CreateStudent(studentDto);
            return Request.CreateResponse(HttpStatusCode.Created, "Student created successfully.");
        }

        [HttpGet]
        [Route("")]
        public HttpResponseMessage GetAllStudents()
        {
            var students = _studentService.GetAllStudents();
            return Request.CreateResponse(HttpStatusCode.OK, students);
        }

        [HttpGet]
        [Route("{id:int}")]
        public HttpResponseMessage GetStudentById(int id)
        {
            var student = _studentService.GetStudentById(id);
            if (student == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Student not found.");
            }

            return Request.CreateResponse(HttpStatusCode.OK, student);
        }

        [Logged]
        [HttpPut]
        [Route("{id:int}")]
        public HttpResponseMessage UpdateStudent(int id, [FromBody] StudentDTO studentDto)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            studentDto.StudentId = id;
            _studentService.UpdateStudent(studentDto);
            return Request.CreateResponse(HttpStatusCode.OK, "Student updated successfully.");
        }

        [Logged]
        [HttpDelete]
        [Route("{id:int}")]
        public HttpResponseMessage DeleteStudent(int id)
        {
            _studentService.DeleteStudent(id);
            return Request.CreateResponse(HttpStatusCode.OK, "Student deleted successfully.");
        }
    }
}