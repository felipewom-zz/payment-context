using System;

namespace PaymentContext.Domain.Entities
{
    public class PayPalPayment : Payment
    {
        public PayPalPayment(DateTime paidDate, DateTime expireDate, string payer, string document, decimal total, decimal totalPaid, string address, string email, string transactionCode) : base( paidDate,  expireDate,  payer,  document,  total,  totalPaid,  address,  email)
        {
            TransactionCode = transactionCode;
        }
        public string TransactionCode { get; private set; }
    }
}