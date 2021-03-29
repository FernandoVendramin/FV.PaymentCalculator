using FV.PaymentCalculator.Core.DTOs;
using FV.PaymentCalculator.Core.Services;
using FV.PaymentCalculator.Core.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace FV.PaymentCalculator.Core.MsTest.Services
{
    [TestClass]
    public class CalcINSSServiceTest
    {
        private readonly CalcINSSService _calcINSSService;
        public CalcINSSServiceTest()
        {
            _calcINSSService = new CalcINSSService();
        }

        [TestMethod]
        [DynamicData(nameof(IsValidData), DynamicDataSourceType.Method)]
        public void Calc_INSS_Ranges_IsValid(CalcPaymentRequest request, CalcPaymentItem paymentItem)
        {
            var response = new CalcPaymentResponse();
            _calcINSSService.Calculate(request, response);

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
                new CalcPaymentRequest(1100),
                new CalcPaymentItem(Messages.INSSItem, 7.5, 0, 82.50)
            };

            yield return new object[]
            {
                new CalcPaymentRequest(2100),
                new CalcPaymentItem(Messages.INSSItem, 9, 0, 172.50)
            };

            yield return new object[]
            {
                new CalcPaymentRequest(3250),
                new CalcPaymentItem(Messages.INSSItem, 12, 0, 307.40)
            };

            yield return new object[]
            {
                new CalcPaymentRequest(5120),
                new CalcPaymentItem(Messages.INSSItem, 14, 0, 568.09)
            };

            yield return new object[]
            {
                new CalcPaymentRequest(21000),
                new CalcPaymentItem(Messages.INSSItem, 14, 0, 751.99)
            };
        }
    }
}
