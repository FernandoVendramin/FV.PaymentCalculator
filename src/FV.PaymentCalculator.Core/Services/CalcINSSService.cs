using FV.PaymentCalculator.Core.DTOs;
using FV.PaymentCalculator.Core.Interfaces;
using FV.PaymentCalculator.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FV.PaymentCalculator.Core.Services
{
    public class CalcINSSService : CalcService, ICalcINSSService
    {
        private readonly TaxConfiguration _taxConfiguration;

        public CalcINSSService()
        {
            _taxConfiguration = new TaxConfiguration();
        }

        public override void Calculate(CalcPaymentRequest reques, CalcPaymentResponse response)
        {
            var calcPaymentItem = new CalcPaymentItem(Messages.INSSItem);
            var calcValues = new Dictionary<double, double>();

            double currentValue = reques.Salary;
            foreach (var item in _taxConfiguration.INSSItens)
            {
                CalcTaxByRange(currentValue, item, _taxConfiguration.INSSItens, calcValues);
            }
            calcPaymentItem.SetReference(calcValues.Max(x => x.Key));
            calcPaymentItem.SetDiscounts(Math.Round(calcValues.Sum(x => x.Key * x.Value / 100), 2));

            response.Data.Itens.Add(calcPaymentItem);
        }
    }
}
