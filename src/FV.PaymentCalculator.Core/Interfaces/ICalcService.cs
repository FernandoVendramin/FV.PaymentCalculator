using FV.PaymentCalculator.Core.DTOs;

namespace FV.PaymentCalculator.Core.Interfaces
{
    public interface ICalcService
    {
        void Calculate(CalcPaymentRequest calcPaymentRequest, CalcPaymentResponse response);
    }
}
