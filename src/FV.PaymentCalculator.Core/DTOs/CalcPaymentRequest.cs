using FV.PaymentCalculator.Core.DTOs.Base;

namespace FV.PaymentCalculator.Core.DTOs
{
    public class CalcPaymentRequest : RequestBase
    {
        public CalcPaymentRequest()
        { }

        public CalcPaymentRequest(
            decimal salary,
            int dependents = 0,
            decimal otherDiscounts = 0,
            decimal healthCareDiscount = 0
            )
        {
            Salary = salary;
            Dependents = dependents;
            OtherDiscounts = otherDiscounts;
            HealthCareDiscount = healthCareDiscount;
        }

        public decimal Salary { get; private set; }
        public int Dependents { get; private set; }
        public decimal OtherDiscounts { get; private set; }
        public decimal HealthCareDiscount { get; private set; }

        public void SetSalary(decimal salary)
        {
            Salary = salary;
        }

        public void SetDependents(int dependents)
        {
            Dependents = dependents;
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
