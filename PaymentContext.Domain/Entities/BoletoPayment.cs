using System;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entities
{
    public class BoletoPayment : Payment
    {
        public BoletoPayment(
            DateTime paidDate,
            DateTime expireDate,
            Document document,
            Address address,
            Email email,
            string payer,
            decimal total,
            decimal totalPaid,
            string barCode,
            string boletoNumber
           
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
            this.BarCode = barCode;
            this.BoletoNumber = boletoNumber;

        }

        public string BarCode { get; private set; }
        public string BoletoNumber { get; private set; }
    }
}