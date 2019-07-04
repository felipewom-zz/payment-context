using System;

namespace PaymentContext.Domain.Entities
{
    public abstract class Payment
    {
        protected Payment(
            DateTime paidDate,
            DateTime expireDate,
            string payer,
            string document,
            decimal total,
            decimal totalPaid,
            string address,
            string email
            )
        {
            Number = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10).ToUpper();
            PaidDate = paidDate;
            ExpireDate = expireDate;
            Payer = payer;
            Document = document;
            Total = total;
            TotalPaid = totalPaid;
            Address = address;
            Email = email;
        }

        public string Number { get; private set; }
        public DateTime PaidDate { get; private set; }
        public DateTime ExpireDate { get; private set; }
        public string Payer { get; private set; }
        public string Document { get; private set; }
        public decimal Total { get; private set; }
        public decimal TotalPaid { get; private set; }
        public string Address { get; private set; }
        public string Email { get; private set; }
    }
}