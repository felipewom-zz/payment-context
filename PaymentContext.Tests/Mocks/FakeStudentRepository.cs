using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Repositories;

namespace PaymentContext.Tests.Mocks
{
    public class FakeStudentRepository : IStudentRepository
    {
        public static string FakeCpf = "9999999999";
        public static string FakeEmail = "teste@teste.com";

        public bool DocumentExists(string document)
        {
            return (document == FakeCpf);
        }

        public bool EmailExists(string email)
        {
            return (email == FakeEmail);
        }

        public void CreateSubscription(Student student)
        {
        }
    }
}