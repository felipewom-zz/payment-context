using System;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entities
{
    public class CreditCardPayment : Payment
    {
        public CreditCardPayment(
            DateTime paidDate,
            DateTime expireDate,
            Document document,
            Address address,
            Email email,
            string payer,
            decimal total,
            decimal totalPaid,
            string cardHolderName,
            string cardNumer,
            string lastTransactionNumber
        ) : base(
            paidDate,
            expireDate,
            payer,
            document,
            total,
            totalPaid,
            address,
            email
        )
        {
            this.CardHolderName = cardHolderName;
            this.CardNumer = cardNumer;
            this.LastTransactionNumber = lastTransactionNumber;
        }

        public string CardHolderName { get; private set; }
        public string CardNumer { get; private set; }
        public string LastTransactionNumber { get; private set; }
    }
}