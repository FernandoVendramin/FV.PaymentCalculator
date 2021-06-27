using FV.PaymentCalculator.Core.Interfaces;
using FV.PaymentCalculator.Core.Models;
using FV.PaymentCalculator.Core.Services;
using FV.PaymentCalculator.Core.Utils;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace FV.PaymentCalculator.Core.XUnitTest.Services
{
    public class CalcOtherDiscountsServiceTest
    {
        private ICalcOtherDiscountsService _calcOtherDiscountsService;

        [Theory]
        [MemberData(nameof(IsValidData))]
        public void Calc_OtherDiscounts_IsValid(Salary salary, decimal value)
        {
            _calcOtherDiscountsService = new CalcOtherDiscountsService(value);
            _calcOtherDiscountsService.Calculate(salary);

            Assert.True(salary.Discounts.Count == 1);
            var item = salary.Discounts.FirstOrDefault();

            Assert.Equal(item.Key, DiscountHelper.GetOthersText);
            Assert.Equal(item.Value, value);
        }

        public static IEnumerable<object[]> IsValidData =>
            new List<object[]>
            {
                new object[] {
                    new Salary(500), 500
                },
                new object[] {
                    new Salary(1000), 1000
                },
                new object[] {
                    new Salary(1100), 1100
                },
                new object[] {
                    new Salary(33), 33
                },
                new object[] {
                    new Salary(123), 132
                },
                new object[] {
                    new Salary((decimal)5.6), 5.6
                }
            };
    }
}
