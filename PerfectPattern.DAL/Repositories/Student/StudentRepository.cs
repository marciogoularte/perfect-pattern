using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NPoco;
using PerfectPattern.DAL.DbFactory;
using PerfectPattern.DAL.Models.Entities;

namespace PerfectPattern.DAL.Repositories.Student
{
    public class StudentRepository : IStudentRepository
    {
        private readonly IDbFactory _dbFactory;

        public StudentRepository(IDbFactory dbFactory)
        {
            _dbFactory = dbFactory;
        }

        public List<Models.Entities.Student> GetAllStudents()
        {
            using (var db = _dbFactory.GetConnection())
            {
                return db.Fetch<Models.Entities.Student>();
            }
        }

        public Models.Entities.Student GetStudentByID(int id)
        {
            using (var db = _dbFactory.GetConnection())
            {
                return db.SingleById<Models.Entities.Student>(id);
            }
        }

        public void AddStudent(Models.Entities.Student student)
        {
            using (var db = _dbFactory.GetConnection())
            {
                db.Insert<Models.Entities.Student>(student);
            }
        }
    }
}