using FV.PaymentCalculator.Core.Interfaces;
using FV.PaymentCalculator.Core.Services;

namespace FV.PaymentCalculator.Core.Factory
{
    public class CalcServiceFactory : ICalcServiceFactory
    {
        public ICalcService GetCalcService(CalcEnum calcEnum)
        {
            if (calcEnum == CalcEnum.INSS)
            {
                return new CalcINSSService();
            }
            else if (calcEnum == CalcEnum.IRRF)
            {
                return new CalcIRRFService();
            }
            else if (calcEnum == CalcEnum.Others)
            {
                return new CalcOtherDiscountsService();
            }

            return null;
        }
    }
}
