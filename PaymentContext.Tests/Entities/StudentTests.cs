using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.Entities
{
    [TestClass]
    public class StudentTests
    {
        [TestMethod]
        public void TestMethod1()
        {
//            var subscription = new Subscription(DateTime.Now.AddYears(2));
//            var student = new Student( "Felipe Moura", Document("123456789", EDocumentType.CPF), "felipewom@gmail.com" );
//            student.AddSubscription(subscription);
                var name = new Name("Felipe", "Moura");
                foreach (var notification in name.Notifications)
                {
                    
                }
        }
    }
}