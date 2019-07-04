using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;

namespace PaymentContext.Tests.Entities
{
    [TestClass]
    public class StudentTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var subscription = new Subscription(DateTime.Now.AddYears(2));
            var student = new Student( "Felipe", "Moura", "123456789", "felipewom@gmail.com" );
            student.AddSubscription(subscription);
        }
    }
}