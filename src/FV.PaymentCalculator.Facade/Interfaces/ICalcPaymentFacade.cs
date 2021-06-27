using FV.PaymentCalculator.Core.DTOs;
using FV.PaymentCalculator.Core.Models;

namespace FV.PaymentCalculator.Facade.Interfaces
{
    public interface ICalcPaymentFacade
    {
        public CalcPaymentResponse Calculate(CalcPaymentRequest request);
    }
}
