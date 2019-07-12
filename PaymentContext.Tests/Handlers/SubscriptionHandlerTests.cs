using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Handlers;
using PaymentContext.Tests.Mocks;

namespace PaymentContext.Tests.Handlers
{
    [TestClass]
    public class SubscriptionHandlerTests
    {
        [TestMethod]
        public void ShouldReturnErrorWhenDocumentExists()
        {
            var handler = new SubscriptionHandler(new FakeStudentRepository(), new FakeEmailService());
            var command = new CreateBoletoSubscriptionCommand();
            command.FirstName = "Bruce";
            command.LastName = "Wayne";
            command.Document = FakeStudentRepository.FakeCpf;
            command.Email = FakeStudentRepository.FakeEmail;
            command.BarCode = "123456789";
            command.BoletoNumber = "123456789";
            command.PaidDate = DateTime.Now;
            command.ExpireDate = DateTime.Now.AddMonths(1);
            command.Total = 60;
            command.TotalPaid = 60;
            command.Payer = "WAYNER CORP";
            command.PayerDocument = "11111111111";
            command.PayerEmail = "batman@dc.com";
            command.PayerDocumentType = EDocumentType.CPF;
            command.Street = "Fake Street";
            command.Number = "123";
            command.Neighborhood = "Fake Neighborhood";
            command.City = "Fake City";
            command.State = "Fake State";
            command.Country = "FC";
            command.ZipCode = "12345678";
            handler.Handle(command);
            Assert.AreEqual(false, handler.Valid);
        }
    }
}