namespace FV.PaymentCalculator.Core.Utils
{
    public class TaxItem
    {
        public int Order { get; set; }
        public decimal Min { get; set; }
        public decimal Max { get; set; }
        public decimal Ref { get; set; }
        public decimal SalaryRange { get; set; }
        public bool Free { get; set; }
    }
}
