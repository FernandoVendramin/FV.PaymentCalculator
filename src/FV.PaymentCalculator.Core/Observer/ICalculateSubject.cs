using FV.PaymentCalculator.Core.DTOs;
using FV.PaymentCalculator.Core.Interfaces;

namespace FV.PaymentCalculator.Core.Observer
{
    public interface ICalculateSubject
    {
        void Attach(ICalcService calcService);

        void Detach(ICalcService calcService);

        void Notify(CalcPaymentRequest calcPaymentRequest, CalcPaymentResponse calcPaymentResponse);
    }
}
