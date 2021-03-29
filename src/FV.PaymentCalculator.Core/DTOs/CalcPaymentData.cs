using System.Collections.Generic;
using System.Linq;

namespace FV.PaymentCalculator.Core.DTOs
{
    public class CalcPaymentData
    {
        public CalcPaymentData()
        {
            Itens = new List<CalcPaymentItem>();
        }

        public CalcPaymentData(
            List<CalcPaymentItem> itens)
        {
            Itens = itens;
        }

        public List<CalcPaymentItem> Itens { get; private set; }
        public double? Total { get => Itens != null ? Itens.Sum(x => x.Earnings) - Itens.Sum(x => x.Discounts) : 0; }
    }
}
