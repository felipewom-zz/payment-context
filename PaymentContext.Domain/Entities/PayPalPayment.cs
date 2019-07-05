using System;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entities
{
    public class PayPalPayment : Payment
    {
        public PayPalPayment(DateTime paidDate, DateTime expireDate, string payer, Document document, decimal total,
            decimal totalPaid, Address address, Email email, string transactionCode)
            : base(paidDate, expireDate, payer, document, total, totalPaid, address, email)
        {
            TransactionCode = transactionCode;
        }

        public string TransactionCode { get; private set; }
    }
}