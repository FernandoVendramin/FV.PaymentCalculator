using FV.PaymentCalculator.Core.DTOs;
using FV.PaymentCalculator.Core.Interfaces;
using FV.PaymentCalculator.Core.Utils;

namespace FV.PaymentCalculator.Core.Services
{
    public class CalcOtherDiscountsService : ICalcOtherDiscountsService
    {
        public void Calculate(CalcPaymentRequest calcPaymentRequest, CalcPaymentResponse response)
        {
            response.Data.Itens.Add(new CalcPaymentItem(Messages.OtherDiscountItem, 0, 0, calcPaymentRequest.Discounts));
        }
    }
}
