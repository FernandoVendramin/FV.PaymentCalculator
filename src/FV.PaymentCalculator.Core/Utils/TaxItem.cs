namespace FV.PaymentCalculator.Core.Utils
{
    public class TaxItem
    {
        public int Order { get; set; }
        public double Min { get; set; }
        public double Max { get; set; }
        public double Ref { get; set; }
        public double SalaryRange { get; set; }
        public bool Free { get; set; }
    }
}
