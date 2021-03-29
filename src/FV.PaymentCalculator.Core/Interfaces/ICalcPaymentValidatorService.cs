using FV.PaymentCalculator.Core.DTOs;

namespace FV.PaymentCalculator.Core.Interfaces
{
    public interface ICalcPaymentValidatorService
    {
        CalcPaymentResponse Validate(CalcPaymentRequest request);
    }
}
