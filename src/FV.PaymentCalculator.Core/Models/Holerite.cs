using FV.PaymentCalculator.Core.Interfaces;
using System.Collections.Generic;

namespace FV.PaymentCalculator.Core.Models
{
    public class Holerite : IHolerite
    {
        private decimal _liquidValue;
        private List<ICalcService> _calcServices = new List<ICalcService>();

        public Holerite(decimal liquidValue)
        {
            _liquidValue = liquidValue;
        }

        public Holerite AddDiscount(ICalcService calcService)
        {
            _calcServices.Add(calcService);
            return this;
        }

        public Salary GetHolerite()
        {
            var salary = new Salary(_liquidValue);
            foreach (var calcService in _calcServices)
            {
                calcService.Calculate(salary);
            }

            return salary;
        }
    }
}
