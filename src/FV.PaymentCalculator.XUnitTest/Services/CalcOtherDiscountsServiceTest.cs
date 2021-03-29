using FV.PaymentCalculator.Core.DTOs;
using FV.PaymentCalculator.Core.Services;
using FV.PaymentCalculator.Core.Utils;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace FV.PaymentCalculator.Core.XUnitTest.Services
{
    public class CalcOtherDiscountsServiceTest
    {
        private readonly CalcOtherDiscountsService _calcOtherDiscountsService;
        public CalcOtherDiscountsServiceTest()
        {
            _calcOtherDiscountsService = new CalcOtherDiscountsService();
        }

        [Theory]
        [MemberData(nameof(IsValidData))]
        public void Calc_OtherDiscounts_IsValid(CalcPaymentRequest request, CalcPaymentItem paymentItem)
        {
            var response = new CalcPaymentResponse();
            _calcOtherDiscountsService.Calculate(request, response);

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
                    new CalcPaymentRequest(0, 0, 500),
                    new CalcPaymentItem(Messages.OtherDiscountItem, 0, 0, 500)
                },
                new object[] {
                    new CalcPaymentRequest(0, 0, 1000),
                    new CalcPaymentItem(Messages.OtherDiscountItem, 0, 0, 1000)
                },
                new object[] {
                    new CalcPaymentRequest(0, 0, 1100),
                    new CalcPaymentItem(Messages.OtherDiscountItem, 0, 0, 1100)
                },
                new object[] {
                    new CalcPaymentRequest(0, 0, 5),
                    new CalcPaymentItem(Messages.OtherDiscountItem, 0, 0, 5)
                },
                new object[] {
                    new CalcPaymentRequest(0, 0, 15),
                    new CalcPaymentItem(Messages.OtherDiscountItem, 0, 0, 15)
                },
                new object[] {
                    new CalcPaymentRequest(0, 0, 3500),
                    new CalcPaymentItem(Messages.OtherDiscountItem, 0, 0, 3500)
                },
                new object[] {
                    new CalcPaymentRequest(0, 0, 2750),
                    new CalcPaymentItem(Messages.OtherDiscountItem, 0, 0, 2750)
                },
                new object[] {
                    new CalcPaymentRequest(0, 0, 123.50),
                    new CalcPaymentItem(Messages.OtherDiscountItem, 0, 0, 123.50)
                },
            };
    }
}
