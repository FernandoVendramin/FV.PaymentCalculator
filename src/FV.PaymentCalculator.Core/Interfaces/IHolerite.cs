using FV.PaymentCalculator.Core.Interfaces;
using FV.PaymentCalculator.Core.Models;

namespace FV.PaymentCalculator.Core.Interfaces
{
    public interface IHolerite
    {
        Salary GetHolerite();

        Holerite AddDiscount(ICalcService calcService);
    }
}
