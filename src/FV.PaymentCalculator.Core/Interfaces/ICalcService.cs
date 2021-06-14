using FV.PaymentCalculator.Core.DTOs;
using FV.PaymentCalculator.Core.Models;

namespace FV.PaymentCalculator.Core.Interfaces
{
    public interface ICalcService
    {
        void Calculate(Salary salary);
    }
}
