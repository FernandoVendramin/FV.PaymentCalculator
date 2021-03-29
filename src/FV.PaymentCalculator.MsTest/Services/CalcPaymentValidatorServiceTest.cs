using Bogus;
using FV.PaymentCalculator.Core.DTOs;
using FV.PaymentCalculator.Core.Services;
using FV.PaymentCalculator.Core.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace FV.PaymentCalculator.Core.MsTest.Services
{
    [TestClass]
    public class CalcPaymentValidatorServiceTest
    {
        private readonly CalcPaymentValidatorService _calcPaymentValidatorService;
        private Faker _faker;

        public CalcPaymentValidatorServiceTest()
        {
            _calcPaymentValidatorService = new CalcPaymentValidatorService();
            _faker = new Faker("pt_BR");
        }

        [TestMethod]
        public void PaymentValidator_IsValid()
        {
            var request = new CalcPaymentRequest();
            var salary = double.Parse(_faker.Finance.Amount(1100, 99999).ToString());

            request.SetSalary(salary);

            var response = _calcPaymentValidatorService.Validate(request);

            Assert.IsTrue(response.Success);
            Assert.AreEqual(response.Messages.Count, 0);
        }

        [TestMethod]
        public void PaymentValidator_IsNotValid()
        {
            var taxConfiguration = new TaxConfiguration();
            var request = new CalcPaymentRequest();
            var salary = double.Parse(_faker.Finance.Amount(0, 1099).ToString());

            request.SetSalary(salary);

            var response = _calcPaymentValidatorService.Validate(request);

            Assert.IsFalse(response.Success);
            Assert.AreNotEqual(response.Messages.Count, 0);
            Assert.AreEqual(response.Messages.FirstOrDefault(), string.Format(Messages.MinimumSalaryValidation, taxConfiguration.MinimumSalary));
        }
    }
}
