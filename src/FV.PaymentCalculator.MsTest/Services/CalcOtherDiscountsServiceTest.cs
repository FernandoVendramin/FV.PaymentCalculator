using FV.PaymentCalculator.Core.DTOs;
using FV.PaymentCalculator.Core.Services;
using FV.PaymentCalculator.Core.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace FV.PaymentCalculator.Core.MsTest.Services
{
    [TestClass]
    public class CalcOtherDiscountsServiceTest
    {
        private readonly CalcOtherDiscountsService _calcOtherDiscountsService;
        public CalcOtherDiscountsServiceTest()
        {
            _calcOtherDiscountsService = new CalcOtherDiscountsService();
        }

        [TestMethod]
        [DynamicData(nameof(IsValidData), DynamicDataSourceType.Method)]
        public void Calc_OtherDiscounts_IsValid(CalcPaymentRequest request, CalcPaymentItem paymentItem)
        {
            var response = new CalcPaymentResponse();
            _calcOtherDiscountsService.Calculate(request, response);

            Assert.IsTrue(response.Data.Itens.Count == 1);
            var item = response.Data.Itens.FirstOrDefault();

            Assert.AreEqual(item.Discounts, paymentItem.Discounts);
            Assert.AreEqual(item.Earnings, paymentItem.Earnings);
            Assert.AreEqual(item.Item, paymentItem.Item);
            Assert.AreEqual(item.Reference, paymentItem.Reference);
        }

        public static IEnumerable<object[]> IsValidData()
        {
            yield return new object[]
            {
                new CalcPaymentRequest(0, 0, 500),
                new CalcPaymentItem(Messages.OtherDiscountItem, 0, 0, 500)
            };

            yield return new object[]
            {
                new CalcPaymentRequest(0, 0, 1000),
                new CalcPaymentItem(Messages.OtherDiscountItem, 0, 0, 1000)
            };

            yield return new object[]
            {
                new CalcPaymentRequest(0, 0, 1100),
                new CalcPaymentItem(Messages.OtherDiscountItem, 0, 0, 1100)
            };

            yield return new object[]
            {
                new CalcPaymentRequest(0, 0, 5),
                new CalcPaymentItem(Messages.OtherDiscountItem, 0, 0, 5)
            };

            yield return new object[]
            {
                new CalcPaymentRequest(0, 0, 15),
                new CalcPaymentItem(Messages.OtherDiscountItem, 0, 0, 15)
            };

            yield return new object[]
            {
                new CalcPaymentRequest(0, 0, 3500),
                new CalcPaymentItem(Messages.OtherDiscountItem, 0, 0, 3500)
            };

            yield return new object[]
            {
                new CalcPaymentRequest(0, 0, 2750),
                new CalcPaymentItem(Messages.OtherDiscountItem, 0, 0, 2750)
            };

            yield return new object[]
            {
                new CalcPaymentRequest(0, 0, 123.50),
                new CalcPaymentItem(Messages.OtherDiscountItem, 0, 0, 123.50)
            };
        }
    }
}
