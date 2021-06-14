using FV.PaymentCalculator.Core.DTOs;
using FV.PaymentCalculator.Core.Interfaces;
using FV.PaymentCalculator.Core.Models;
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

        public override void Calculate(Salary salary)
        {
            var calcPaymentItem = new CalcPaymentItem(Messages.INSSItem);
            var calcValues = new Dictionary<decimal, decimal>();

            //decimal currentValue = salary.Value;
            foreach (var item in _taxConfiguration.INSSItens)
            {
                CalcTaxByRange(salary.Value, item, _taxConfiguration.INSSItens, calcValues);
            }

            var discount = (decimal)Math.Round(calcValues.Sum(x => x.Key * x.Value / 100), 2);
            salary.Value = salary.Value - discount;
            salary.Disconts.Add($"INSS - {calcValues.Max(x => x.Key)} %", discount);
        }
    }
}
