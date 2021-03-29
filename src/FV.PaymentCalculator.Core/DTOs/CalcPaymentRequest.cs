using FV.PaymentCalculator.Core.DTOs.Base;

namespace FV.PaymentCalculator.Core.DTOs
{
    public class CalcPaymentRequest : RequestBase
    {
        public CalcPaymentRequest()
        { }

        public CalcPaymentRequest(
            double salary,
            int dependents = 0,
            double discounts = 0
            )
        {
            Salary = salary;
            Dependents = dependents;
            Discounts = discounts;
        }

        public double Salary { get; private set; }
        public int Dependents { get; private set; }
        public double Discounts { get; private set; }

        public void SetSalary(double salary)
        {
            Salary = salary;
        }

        public void SetDependents(int dependents)
        {
            Dependents = dependents;
        }

        public void SetDiscounts(double discounts)
        {
            Discounts = discounts;
        }
    }
}
