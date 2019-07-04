using System;

namespace PaymentContext.Domain.Entities
{
    public class BoletoPayment : Payment
    {
        public BoletoPayment(
            DateTime paidDate,
            DateTime expireDate,
            string payer,
            string document,
            decimal total,
            decimal totalPaid,
            string address,
            string email,
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