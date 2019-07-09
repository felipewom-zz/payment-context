using System;
using Flunt.Validations;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entities
{
    public abstract class Payment : Entity
    {
        protected Payment(
            DateTime paidDate,
            DateTime expireDate,
            string payer,
            Document document,
            decimal total,
            decimal totalPaid,
            Address address,
            Email email
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
            
            AddNotifications(new Contract()
                .Requires()
                .IsGreaterThan(Total, 0, "Payment.Total", "O total não pode ser zero.")
                .IsGreaterOrEqualsThan(Total, TotalPaid, "Payment.TotalPaid", "O valor pago tem que ser igual ou menor que o total."));
        }

        public string Number { get; private set; }
        public DateTime PaidDate { get; private set; }
        public DateTime ExpireDate { get; private set; }
        public string Payer { get; private set; }
        public Document Document { get; private set; }
        public decimal Total { get; private set; }
        public decimal TotalPaid { get; private set; }
        public Address Address { get; private set; }
        public Email Email { get; private set; }
    }
}