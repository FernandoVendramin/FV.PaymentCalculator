using FV.PaymentCalculator.Core.DTOs;
using FV.PaymentCalculator.Core.Services;
using FV.PaymentCalculator.Core.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace FV.PaymentCalculator.Core.MsTest.Services
{
    [TestClass]
    public class CalcIRRFServiceTest
    {
        private readonly CalcIRRFService _calcIRRFService;
        public CalcIRRFServiceTest()
        {
            _calcIRRFService = new CalcIRRFService();
        }

        [TestMethod]
        [DynamicData(nameof(IsValidData), DynamicDataSourceType.Method)]
        public void Calc_IRRF_Ranges_IsValid(CalcPaymentData calcPaymentData, CalcPaymentItem paymentItem)
        {
            var response = new CalcPaymentResponse();
            var request = new CalcPaymentRequest();
            response.SetData(calcPaymentData);

            _calcIRRFService.Calculate(request, response);

            Assert.IsTrue(response.Data.Itens.Count == 3);
            var item = response.Data.Itens
                .Where(x => x.Item == Messages.IRRFItem)
                .FirstOrDefault();

            Assert.AreEqual(item.Discounts, paymentItem.Discounts);
            Assert.AreEqual(item.Earnings, paymentItem.Earnings);
            Assert.AreEqual(item.Item, paymentItem.Item);
            Assert.AreEqual(item.Reference, paymentItem.Reference);
        }

        public static IEnumerable<object[]> IsValidData()
        {
            yield return new object[]
            {
                new CalcPaymentData(
                    new List<CalcPaymentItem>()
                    {
                        new CalcPaymentItem(Messages.RawSalaryItem, 0, 1100, 0),
                        new CalcPaymentItem(Messages.INSSItem, 7.5, 0, 82.50)
                    }),
                new CalcPaymentItem(Messages.IRRFItem, 0, 0, 0) { }
            };

            yield return new object[]
            {
                new CalcPaymentData(
                    new List<CalcPaymentItem>()
                    {
                        new CalcPaymentItem(Messages.RawSalaryItem, 0, 2100, 0),
                        new CalcPaymentItem(Messages.INSSItem, 9, 0, 172.50)
                    }),
                new CalcPaymentItem(Messages.IRRFItem, 7.5, 0, 1.76) { }
            };

            yield return new object[]
            {
                new CalcPaymentData(
                    new List<CalcPaymentItem>()
                    {
                        new CalcPaymentItem(Messages.RawSalaryItem, 0, 3250, 0),
                        new CalcPaymentItem(Messages.INSSItem, 12, 0, 307.40)
                    }),
                new CalcPaymentItem(Messages.IRRFItem, 15, 0, 86.59) { }
            };

            yield return new object[]
            {
                new CalcPaymentData(
                    new List<CalcPaymentItem>()
                    {
                        new CalcPaymentItem(Messages.RawSalaryItem, 0, 5120, 0),
                        new CalcPaymentItem(Messages.INSSItem, 14, 0, 568.09)
                    }),
                new CalcPaymentItem(Messages.IRRFItem, 22.5, 0, 388.05) { }
            };

            yield return new object[]
            {
                new CalcPaymentData(
                    new List<CalcPaymentItem>()
                    {
                        new CalcPaymentItem(Messages.RawSalaryItem, 0, 21000, 0),
                        new CalcPaymentItem(Messages.INSSItem, 14, 0, 751.99)
                    }),
                new CalcPaymentItem(Messages.IRRFItem, 27.5, 0, 4698.84) { }
            };

        }
    }
}
