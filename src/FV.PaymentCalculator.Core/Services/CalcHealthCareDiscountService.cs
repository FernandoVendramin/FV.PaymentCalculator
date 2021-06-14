﻿using FV.PaymentCalculator.Core.Interfaces;
using FV.PaymentCalculator.Core.Models;

namespace FV.PaymentCalculator.Core.Services
{
    public class CalcHealthCareDiscountService : ICalcHealthCareDiscountService
    {
        private readonly decimal _value = 0;

        public CalcHealthCareDiscountService(decimal value)
        {
            _value = value;
        }

        public void Calculate(Salary salary)
        {
            salary.Value = salary.Value - _value;
            salary.Disconts.Add("Health Care", _value);
        }
    }
}
