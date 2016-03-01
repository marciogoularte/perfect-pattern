using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectPattern.DAL.Repositories.Student
{
    public interface IStudentRepository
    {
        List<Models.Entities.Student> GetAllStudents();
        Models.Entities.Student GetStudentByID(int id);
        void AddStudent(Models.Entities.Student student);
    }
}
