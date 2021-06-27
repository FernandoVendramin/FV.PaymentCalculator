using FV.PaymentCalculator.Core.DTOs;
using FV.PaymentCalculator.Core.Interfaces;
using FV.PaymentCalculator.Core.Models;
using FV.PaymentCalculator.Core.Services;
using FV.PaymentCalculator.Core.Utils;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace FV.PaymentCalculator.Core.XUnitTest.Services
{
    public class CalcIRRFServiceTest
    {
        private readonly ICalcIRRFService _calcIRRFService;
        public CalcIRRFServiceTest()
        {
            _calcIRRFService = new CalcIRRFService();
        }

        [Theory]
        [MemberData(nameof(IsValidData))]
        public void Calc_IRRF_Ranges_IsValid(Salary salary, decimal percent, decimal value)
        {
            _calcIRRFService.Calculate(salary);

            Assert.True(salary.Discounts.Count == 1);
            var item = salary.Discounts.FirstOrDefault();

            Assert.Equal(item.Key, DiscountHelper.GetIRRFText(percent));
            Assert.Equal(item.Value, value);
        }

        public static IEnumerable<object[]> IsValidData =>
            new List<object[]>
            {
                new object[] {
                    new Salary(1100), 0, 0
                },
                new object[] {
                    new Salary((decimal)1927.5), 7.5, 1.76
                },
                new object[] {
                    new Salary((decimal)2942.6), 15, 86.59
                },
                new object[] {
                    new Salary((decimal)4551.91), 22.5, 388.05
                },
                new object[] {
                    new Salary((decimal)20248.01), 27.5, 4698.84
                }
            };
    }
}
