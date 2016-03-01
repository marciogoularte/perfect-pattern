using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using PerfectPattern.DAL.DbFactory;
using NPoco;
using PerfectPattern.DAL.Models.Entities;
using PerfectPattern.DAL.Repositories.Student;

namespace PerfectPattern.Test.Repositories.Student
{
    [TestClass]
    public class StudentRepositoryTest
    {
        private Mock<IDbFactory> _mockDbFactory;
        private Mock<IDatabase> _mockDatabase;

        // System Under Test (SUT)
        private IStudentRepository _studentRepository;

        [TestInitialize]
        public void Setup()
        {
            _mockDatabase = new Mock<IDatabase>();
            _mockDatabase.VerifyAll();

            _mockDbFactory = new Mock<IDbFactory>();

            _mockDbFactory.Setup(x => x.GetConnection())
                .Returns(_mockDatabase.Object);

            _studentRepository = new StudentRepository(_mockDbFactory.Object);
        }

        [TestMethod]
        public void GetAllStudentsTest()
        {
            // Act
            var students = _studentRepository.GetAllStudents();

            // Assert
            _mockDatabase.Verify(x => x.Fetch<DAL.Models.Entities.Student>(), Times.Once);
        }

        [TestMethod]
        public void GetSingleStudentTest()
        {
            // Arrange
            int studentID = 1;

            // Act
            var students = _studentRepository.GetStudentByID(studentID);

            // Assert
            _mockDatabase.Verify(x => x.SingleById<DAL.Models.Entities.Student>(studentID), Times.Once);
        }

        [TestMethod]
        public void InsertStudentTest()
        {
            // Arrange
            DAL.Models.Entities.Student newStudent = new DAL.Models.Entities.Student
            {
                ID = 2,
                Name = "Conor McGregor",
                Age = 30
            };

            // Act
            _studentRepository.AddStudent(newStudent);

            // Assert
            _mockDatabase.Verify(x => x.Insert<DAL.Models.Entities.Student>(newStudent), Times.Once);
        }
    }
}
