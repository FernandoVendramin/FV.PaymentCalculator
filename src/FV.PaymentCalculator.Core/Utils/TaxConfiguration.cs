using System.Collections.Generic;

namespace FV.PaymentCalculator.Core.Utils
{
    public class TaxConfiguration
    {
        public TaxConfiguration()
        {
            INSSItens = new List<TaxItem>();
            INSSItens.Add(new TaxItem() { Order = 1, Min = 0, Max = 1100, Ref = 7.5, SalaryRange = 1100 });
            INSSItens.Add(new TaxItem() { Order = 2, Min = 1100.01, Max = 2203.48, Ref = 9, SalaryRange = 1103.48 });
            INSSItens.Add(new TaxItem() { Order = 3, Min = 2203.49, Max = 3305.22, Ref = 12, SalaryRange = 1101.74 });
            INSSItens.Add(new TaxItem() { Order = 4, Min = 3305.23, Max = 6433.57, Ref = 14, SalaryRange = 3128.35 });

            IRRFItens = new List<TaxItem>();
            IRRFItens.Add(new TaxItem() { Order = 1, Min = 0, Max = 1903.98, Ref = 0, SalaryRange = 1903.98, Free = true });
            IRRFItens.Add(new TaxItem() { Order = 2, Min = 1903.99, Max = 2826.65, Ref = 7.5, SalaryRange = 922.67, Free = false });
            IRRFItens.Add(new TaxItem() { Order = 3, Min = 2826.66, Max = 3751.05, Ref = 15, SalaryRange = 924.40, Free = false });
            IRRFItens.Add(new TaxItem() { Order = 4, Min = 3751.06, Max = 4664.68, Ref = 22.5, SalaryRange = 913.63, Free = false });
            IRRFItens.Add(new TaxItem() { Order = 5, Min = 4664.69, Max = 5000, Ref = 27.5, SalaryRange = 0, Free = false });
        }

        public double MinimumSalary = 1100;

        public List<TaxItem> INSSItens { get; set; }
        public List<TaxItem> IRRFItens { get; set; }
    }
}
