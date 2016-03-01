using PerfectPattern.BLL.Services;
using PerfectPattern.Common.Models.DTO;
using PerfectPattern.DAL.Repositories.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PerfectPattern.API.Controllers
{
    [RoutePrefix("students")]
    public class StudentController : ApiController
    {
        private readonly IStudentRepository _studentRepository;

        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [HttpGet]
        [Route("")]
        public List<StudentDTO> GetAllStudents()
        {
            var studentService = new StudentService(_studentRepository);

            var students = studentService.GetAllStudents();

            return students;
        }

        [HttpGet]
        [Route("{id}")]
        public StudentDTO GetStudentByID(int id)
        {
            var studentService = new StudentService(_studentRepository);

            var student = studentService.GetStudentByID(id);

            return student;
        }
    }
}