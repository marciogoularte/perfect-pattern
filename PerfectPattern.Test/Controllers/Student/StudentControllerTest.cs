using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using PerfectPattern.BLL.Services;
using PerfectPattern.DAL.Models.Entities;
using PerfectPattern.DAL.Repositories.Student;
using PerfectPattern.API.Controllers;
using PerfectPattern.Common.Models.DTO;

namespace PerfectPattern.Test.Controllers.Student
{
    [TestClass]
    public class StudentControllerTest
    {
        private Mock<IStudentRepository> _mockStudentRepository;

        // System Under Test (SUT)
        private StudentController _studentController;

        [TestInitialize]
        public void Setup()
        {
            List<DAL.Models.Entities.Student> inMemoryStudentList = new List<DAL.Models.Entities.Student>
            {
                new DAL.Models.Entities.Student
                {
                    ID = 1,
                    Name = "John Doe",
                    Age = 28
                }
            };

            _mockStudentRepository = new Mock<IStudentRepository>();

            _mockStudentRepository.Setup(x => x.GetAllStudents())
                .Returns(inMemoryStudentList);

            _mockStudentRepository.Setup(x => x.GetStudentByID(It.IsAny<int>()))
                .Returns(inMemoryStudentList[0]);

            _studentController = new StudentController(_mockStudentRepository.Object);
        }

        [TestMethod]
        public void GetAllStudentsTest()
        {
            // Act
            var students = _studentController.GetAllStudents();

            // Assert
            _mockStudentRepository.Verify(x => x.GetAllStudents(), Times.Once);
            Assert.IsInstanceOfType(students, typeof(List<StudentDTO>), "Return type is not correct");
            Assert.AreEqual(1, students.Count, "Student count is not correct");
        }

        [TestMethod]
        public void GetSingleStudentTest()
        {
            // Arrange
            int studentID = 1;

            // Act
            var student = _studentController.GetStudentByID(studentID);

            // Assert
            _mockStudentRepository.Verify(x => x.GetStudentByID(studentID), Times.Once);
            Assert.IsInstanceOfType(student, typeof(StudentDTO), "Return type is not correct");
            Assert.AreEqual("John Doe", student.Name, "Student name is not correct");
            Assert.AreEqual(28, student.Age, "Student age is not correct");
        }
    }
}
