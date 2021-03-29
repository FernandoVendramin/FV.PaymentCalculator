using FV.PaymentCalculator.Core.DTOs;
using FV.PaymentCalculator.Core.Services;
using FV.PaymentCalculator.Core.Utils;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace FV.PaymentCalculator.Core.XUnitTest.Services
{
    public class CalcINSSServiceTest
    {
        private readonly CalcINSSService _calcINSSService;
        public CalcINSSServiceTest()
        {
            _calcINSSService = new CalcINSSService();
        }

        [Theory]
        [MemberData(nameof(IsValidData))]
        public void Calc_INSS_Ranges_IsValid(CalcPaymentRequest request, CalcPaymentItem paymentItem)
        {
            var response = new CalcPaymentResponse();
            _calcINSSService.Calculate(request, response);

            Assert.True(response.Data.Itens.Count == 1);
            var item = response.Data.Itens.FirstOrDefault();

            Assert.Equal(item.Discounts, paymentItem.Discounts);
            Assert.Equal(item.Earnings, paymentItem.Earnings);
            Assert.Equal(item.Item, paymentItem.Item);
            Assert.Equal(item.Reference, paymentItem.Reference);
        }

        public static IEnumerable<object[]> IsValidData =>
            new List<object[]>
            {
                new object[] {
                    new CalcPaymentRequest(1100),
                    new CalcPaymentItem(Messages.INSSItem, 7.5, 0, 82.50)
                },
                new object[] {
                    new CalcPaymentRequest(2100),
                    new CalcPaymentItem(Messages.INSSItem, 9, 0, 172.50)
                },
                new object[] {
                    new CalcPaymentRequest(3250),
                    new CalcPaymentItem(Messages.INSSItem, 12, 0, 307.40)
                },
                new object[] {
                    new CalcPaymentRequest(5120),
                    new CalcPaymentItem(Messages.INSSItem, 14, 0, 568.09)
                },
                 new object[] {
                    new CalcPaymentRequest(21000),
                    new CalcPaymentItem(Messages.INSSItem, 14, 0, 751.99)
                },
            };
    }
}
