using PerfectPattern.Common.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PerfectPattern.Common.Extensions;
using PerfectPattern.DAL.Models.Entities;
using PerfectPattern.DAL.Repositories.Student;

namespace PerfectPattern.BLL.Services
{
    public class StudentService
    {
        private IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public List<StudentDTO> GetAllStudents()
        {
            var students = _studentRepository.GetAllStudents();

            return students.ToDTO<StudentDTO>().ToList();
        }

        public StudentDTO GetStudentByID(int id)
        {
            var student = _studentRepository.GetStudentByID(id);

            return student.ToDTO<StudentDTO>();
        }

        public void AddStudent(StudentDTO student)
        {
            var studentEntity = student.ToDTO<Student>();

            _studentRepository.AddStudent(studentEntity);
        }
    }
}
