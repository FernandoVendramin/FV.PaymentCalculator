using System.Collections.Generic;

namespace FV.PaymentCalculator.Core.Models
{
    public class Salary
    {
        public Salary(decimal liquidValue)
        {
            this.Disconts = new Dictionary<string, decimal>();
            LiquidValue = liquidValue;
            Value = liquidValue;
        }

        public string Name { get; set; }
        public decimal LiquidValue { get; set; }
        public decimal Value { get; set; }
        public Dictionary<string, decimal> Disconts { get; set; }
    }
}
