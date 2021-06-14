using System.Collections.Generic;

namespace FV.PaymentCalculator.Core.Utils
{
    public class TaxConfiguration
    {
        public TaxConfiguration()
        {
            INSSItens = new List<TaxItem>();
            INSSItens.Add(new TaxItem() { Order = 1, Min = 0, Max = 1100, Ref = (decimal)7.5, SalaryRange = 1100 });
            INSSItens.Add(new TaxItem() { Order = 2, Min = (decimal)1100.01, Max = (decimal)2203.48, Ref = 9, SalaryRange = (decimal)1103.48 });
            INSSItens.Add(new TaxItem() { Order = 3, Min = (decimal)2203.49, Max = (decimal)3305.22, Ref = 12, SalaryRange = (decimal)1101.74 });
            INSSItens.Add(new TaxItem() { Order = 4, Min = (decimal)3305.23, Max = (decimal)6433.57, Ref = 14, SalaryRange = (decimal)3128.35 });

            IRRFItens = new List<TaxItem>();
            IRRFItens.Add(new TaxItem() { Order = 1, Min = 0, Max = (decimal)1903.98, Ref = 0, SalaryRange = (decimal)1903.98, Free = true });
            IRRFItens.Add(new TaxItem() { Order = 2, Min = (decimal)1903.99, Max = (decimal)2826.65, Ref = (decimal)7.5, SalaryRange = (decimal)922.67, Free = false });
            IRRFItens.Add(new TaxItem() { Order = 3, Min = (decimal)2826.66, Max = (decimal)3751.05, Ref = (decimal)15, SalaryRange = (decimal)924.40, Free = false });
            IRRFItens.Add(new TaxItem() { Order = 4, Min = (decimal)3751.06, Max = (decimal)4664.68, Ref = (decimal)22.5, SalaryRange = (decimal)913.63, Free = false });
            IRRFItens.Add(new TaxItem() { Order = 5, Min = (decimal)4664.69, Max = (decimal)5000, Ref = (decimal)27.5, SalaryRange = 0, Free = false });
        }

        public decimal MinimumSalary = 1100;

        public List<TaxItem> INSSItens { get; set; }
        public List<TaxItem> IRRFItens { get; set; }
    }
}
