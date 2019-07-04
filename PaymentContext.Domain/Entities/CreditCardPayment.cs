using System;

namespace PaymentContext.Domain.Entities
{
    public class CreditCardPayment : Payment
    {
        public CreditCardPayment(
            DateTime paidDate,
            DateTime expireDate,
            string payer,
            string document,
            decimal total,
            decimal totalPaid,
            string address,
            string email,
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