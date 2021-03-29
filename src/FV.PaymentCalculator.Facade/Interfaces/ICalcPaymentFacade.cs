using FV.PaymentCalculator.Core.DTOs;

namespace FV.PaymentCalculator.Facade.Interfaces
{
    public interface ICalcPaymentFacade
    {
        public CalcPaymentResponse Calculate(CalcPaymentRequest request);
    }
}
