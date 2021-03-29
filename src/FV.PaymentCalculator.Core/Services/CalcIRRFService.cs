using FV.PaymentCalculator.Core.DTOs;
using FV.PaymentCalculator.Core.Interfaces;
using FV.PaymentCalculator.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FV.PaymentCalculator.Core.Services
{
    public class CalcIRRFService : CalcService, ICalcIRRFService
    {
        private readonly TaxConfiguration _taxConfiguration;

        public CalcIRRFService()
        {
            _taxConfiguration = new TaxConfiguration();
        }

        public override void Calculate(CalcPaymentRequest request, CalcPaymentResponse response)
        {
            var calcPaymentItem = new CalcPaymentItem(Messages.IRRFItem);
            var calcValues = new Dictionary<double, double>();

            var currentSalary = response.Data.Itens != null
                ? response.Data.Itens.Sum(x => x.Earnings) - response.Data.Itens.Sum(x => x.Discounts)
                : 0;

            double currentValue = currentSalary;
            foreach (var item in _taxConfiguration.IRRFItens)
            {
                CalcTaxByRange(currentValue, item, _taxConfiguration.IRRFItens, calcValues);
            }
            calcPaymentItem.SetReference(calcValues.Max(x => x.Key));
            calcPaymentItem.SetDiscounts(Math.Round(calcValues.Sum(x => x.Key * x.Value / 100), 2));

            response.Data.Itens.Add(calcPaymentItem);
        }
    }
}
