using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Queries;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Tests.Mocks;

namespace PaymentContext.Tests.Queries
{
    [TestClass]
    public class StudentQueriesTests
    {
        private IList<Student> _students = new List<Student>();

        public StudentQueriesTests()
        {
            for (int i = 0; i <= 10; i++)
            {
                _students.Add(new Student(
                        new Name($"Aluno {i}", i.ToString()),
                        new Document("1111111111"+i, EDocumentType.CPF),
                        new Email($"fake{i}@email.com")
                    )
                );
            }
            _students.Add(new Student(
                    new Name($"Aluno X", "XXXX"),
                    new Document(FakeStudentRepository.FakeCpf, EDocumentType.CPF),
                    new Email(FakeStudentRepository.FakeEmail)
                )
            );
        }

        [TestMethod]
        public void ShouldReturnErrorWhenDocumentNotExists()
        {
            var exp = StudentQueries.GetStudent("12345678910");
            var student = _students.AsQueryable().Where(exp).FirstOrDefault();
            Assert.AreEqual(null, student);
        }

        [TestMethod]
        public void ShouldReturnStudentWhenDocumentExists()
        {
            var exp = StudentQueries.GetStudent(FakeStudentRepository.FakeCpf);
            var student = _students.AsQueryable().Where(exp).FirstOrDefault();
            Assert.AreNotEqual(null, student);
        }
    }
}