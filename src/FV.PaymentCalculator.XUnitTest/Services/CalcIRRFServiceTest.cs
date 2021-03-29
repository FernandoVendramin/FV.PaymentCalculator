using FV.PaymentCalculator.Core.DTOs;
using FV.PaymentCalculator.Core.Services;
using FV.PaymentCalculator.Core.Utils;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace FV.PaymentCalculator.Core.XUnitTest.Services
{
    public class CalcIRRFServiceTest
    {
        private readonly CalcIRRFService _calcIRRFService;
        public CalcIRRFServiceTest()
        {
            _calcIRRFService = new CalcIRRFService();
        }

        [Theory]
        [MemberData(nameof(IsValidData))]
        public void Calc_IRRF_Ranges_IsValid(CalcPaymentData calcPaymentData, CalcPaymentItem paymentItem)
        {
            var response = new CalcPaymentResponse();
            var request = new CalcPaymentRequest();
            response.SetData(calcPaymentData);

            _calcIRRFService.Calculate(request, response);

            Assert.True(response.Data.Itens.Count == 3);
            var item = response.Data.Itens
                .Where(x => x.Item == Messages.IRRFItem)
                .FirstOrDefault();

            Assert.Equal(item.Discounts, paymentItem.Discounts);
            Assert.Equal(item.Earnings, paymentItem.Earnings);
            Assert.Equal(item.Item, paymentItem.Item);
            Assert.Equal(item.Reference, paymentItem.Reference);
        }

        public static IEnumerable<object[]> IsValidData =>
            new List<object[]>
            {
                new object[] {
                    new CalcPaymentData(
                        new List<CalcPaymentItem>()
                        {
                            new CalcPaymentItem(Messages.RawSalaryItem, 0, 1100, 0),
                            new CalcPaymentItem(Messages.INSSItem, 7.5, 0, 82.50)
                        }),
                    new CalcPaymentItem(Messages.IRRFItem, 0, 0, 0) { }
                },
                new object[] {
                    new CalcPaymentData(
                        new List<CalcPaymentItem>()
                        {
                            new CalcPaymentItem(Messages.RawSalaryItem, 0, 2100, 0),
                            new CalcPaymentItem(Messages.INSSItem, 9, 0, 172.50)
                        }),
                    new CalcPaymentItem(Messages.IRRFItem, 7.5, 0, 1.76) { }
                },
                new object[] {
                    new CalcPaymentData(
                        new List<CalcPaymentItem>()
                        {
                            new CalcPaymentItem(Messages.RawSalaryItem, 0, 3250, 0),
                            new CalcPaymentItem(Messages.INSSItem, 12, 0, 307.40)
                        }),
                    new CalcPaymentItem(Messages.IRRFItem, 15, 0, 86.59) { }
                },
                new object[] {
                    new CalcPaymentData(
                        new List<CalcPaymentItem>()
                        {
                            new CalcPaymentItem(Messages.RawSalaryItem, 0, 5120, 0),
                            new CalcPaymentItem(Messages.INSSItem, 14, 0, 568.09)
                        }),
                    new CalcPaymentItem(Messages.IRRFItem, 22.5, 0, 388.05) { }
                },
                new object[] {
                    new CalcPaymentData(
                        new List<CalcPaymentItem>()
                        {
                            new CalcPaymentItem(Messages.RawSalaryItem, 0, 21000, 0),
                            new CalcPaymentItem(Messages.INSSItem, 14, 0, 751.99)
                        }),
                    new CalcPaymentItem(Messages.IRRFItem, 27.5, 0, 4698.84) { }
                },
            };
    }
}
