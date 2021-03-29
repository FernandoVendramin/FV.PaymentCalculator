namespace FV.PaymentCalculator.Core.DTOs
{
    public class CalcPaymentItem
    {
        public CalcPaymentItem(string item)
        {
            Item = item;
        }

        public CalcPaymentItem(
            string item,
            double? reference,
            double earnings,
            double discount)
        {
            Item = item;
            Reference = reference;
            Earnings = earnings;
            Discounts = discount;
        }

        public string Item { get; private set; }
        public double? Reference { get; private set; }
        public double Earnings { get; private set; }
        public double Discounts { get; private set; }

        public void SetReference(double reference)
        {
            Reference = reference;
        }

        public void SetEarnings(double earnings)
        {
            Earnings = earnings;
        }

        public void SetDiscounts(double discounts)
        {
            Discounts = discounts;
        }
    }
}
