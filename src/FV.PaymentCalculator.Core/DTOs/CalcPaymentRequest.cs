using FV.PaymentCalculator.Core.DTOs.Base;

namespace FV.PaymentCalculator.Core.DTOs
{
    public class CalcPaymentRequest : RequestBase
    {
        public CalcPaymentRequest()
        { }

        public CalcPaymentRequest(
            decimal salary,
            decimal otherDiscounts = 0,
            decimal healthCareDiscount = 0
            )
        {
            Salary = salary;
            OtherDiscounts = otherDiscounts;
            HealthCareDiscount = healthCareDiscount;
        }

        public decimal Salary { get; private set; }
        public decimal OtherDiscounts { get; private set; }
        public decimal HealthCareDiscount { get; private set; }

        public void SetSalary(decimal salary)
        {
            Salary = salary;
        }

        public void SetOtherDiscounts(decimal discounts)
        {
            OtherDiscounts = discounts;
        }

        public void SetHealthCareDiscount(decimal discounts)
        {
            HealthCareDiscount = discounts;
        }
    }
}
