using FV.PaymentCalculator.Core.Interfaces;
using FV.PaymentCalculator.Core.Models;
using FV.PaymentCalculator.Core.Services;
using FV.PaymentCalculator.Core.Utils;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace FV.PaymentCalculator.Core.XUnitTest.Services
{
    public class CalcINSSServiceTest
    {
        private readonly ICalcINSSService _calcINSSService;
        public CalcINSSServiceTest()
        {
            _calcINSSService = new CalcINSSService();
        }

        [Theory]
        [MemberData(nameof(IsValidData))]
        public void Calc_INSS_Ranges_IsValid(Salary salary, decimal percent, decimal value)
        {
            _calcINSSService.Calculate(salary);

            Assert.True(salary.Discounts.Count == 1);
            var item = salary.Discounts.FirstOrDefault();

            Assert.Equal(item.Key, DiscountHelper.GetINSSText(percent));
            Assert.Equal(item.Value, value);
        }

        public static IEnumerable<object[]> IsValidData =>
            new List<object[]>
            {
                new object[] {
                    new Salary(1100), 7.5, 82.50
                },
                new object[] {
                    new Salary(2100), 9, 172.50
                },
                new object[] {
                    new Salary(3250), 12, 307.40
                },
                new object[] {
                    new Salary(5120), 14, 568.09
                },
                new object[] {
                    new Salary(21000), 14, 751.99
                }
            };
    }
}
