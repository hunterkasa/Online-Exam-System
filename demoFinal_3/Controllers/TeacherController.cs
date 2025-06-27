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
    [RoutePrefix("api/teacher")]
    public class TeacherController : ApiController
    {
        private TeacherService teacherService;

        public TeacherController() {
            teacherService = new TeacherService();
        }

        [HttpGet]
        [Route("")]
        public HttpResponseMessage GetAllTeachers()
        {
            var teachers = teacherService.GetAllTeachers();
            if (teachers == null || !teachers.Any()){
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No teachers found.");
            } 
            return Request.CreateResponse(HttpStatusCode.OK, teachers);
        }

        [HttpGet]
        [Route("{id:int}")]
        public HttpResponseMessage GetTeacherById(int id)
        {
            var teacher = teacherService.GetTeacherById(id);
            if (teacher == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Teacher not found.");
            }

            return Request.CreateResponse(HttpStatusCode.OK, teacher);
        }

        [Logged]
        [HttpPut]
        [Route("{id:int}")]
        public HttpResponseMessage UpdateTeacher(int id, [FromBody] TeacherDTO teacherDto)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            teacherDto.TeacherId = id;
            teacherService.UpdateTeacher(teacherDto);
            return Request.CreateResponse(HttpStatusCode.OK, "Teacher updated successfully.");
        }

        [Logged]
        [HttpDelete]
        [Route("{id:int}")]
        public HttpResponseMessage DeleteTeacher(int id)
        {
            teacherService.DeleteTeacher(id);
            return Request.CreateResponse(HttpStatusCode.OK, "Teacher deleted successfully.");
        }

    }
}