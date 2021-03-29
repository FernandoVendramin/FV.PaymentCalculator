using FV.PaymentCalculator.Core.Interfaces;

namespace FV.PaymentCalculator.Core.Factory
{
    public interface ICalcServiceFactory
    {
        ICalcService GetCalcService(CalcEnum calcEnum);
    }
}
