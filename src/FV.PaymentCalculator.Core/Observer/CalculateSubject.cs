using FV.PaymentCalculator.Core.DTOs;
using FV.PaymentCalculator.Core.Interfaces;
using System.Collections.Generic;

namespace FV.PaymentCalculator.Core.Observer
{
    public class CalculateSubject : ICalculateSubject
    {
        private List<ICalcService> _calcServices = new List<ICalcService>();

        public void Attach(ICalcService calcService)
        {
            _calcServices.Add(calcService);
        }

        public void Detach(ICalcService calcService)
        {
            _calcServices.Remove(calcService);
        }

        public void Notify(CalcPaymentRequest calcPaymentRequest, CalcPaymentResponse calcPaymentResponse)
        {
            foreach (var calcService in _calcServices)
            {
                calcService.Calculate(calcPaymentRequest, calcPaymentResponse);
            }
        }

        public void Execute(CalcPaymentRequest calcPaymentRequest, CalcPaymentResponse calcPaymentResponse)
        {
            Notify(calcPaymentRequest, calcPaymentResponse);
        }
    }
}
