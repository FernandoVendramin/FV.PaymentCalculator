using Bogus;
using FV.PaymentCalculator.Core.DTOs;
using FV.PaymentCalculator.Core.Services;
using FV.PaymentCalculator.Core.Utils;
using System.Linq;
using Xunit;

namespace FV.PaymentCalculator.Core.XUnitTest.Services
{
    public class CalcPaymentValidatorServiceTest
    {
        private readonly CalcPaymentValidatorService _calcPaymentValidatorService;
        private Faker _faker;

        public CalcPaymentValidatorServiceTest()
        {
            _calcPaymentValidatorService = new CalcPaymentValidatorService();
            _faker = new Faker("pt_BR");
        }

        [Fact]
        public void PaymentValidator_IsValid()
        {
            var request = new CalcPaymentRequest();
            var salary = decimal.Parse(_faker.Finance.Amount(1100, 99999).ToString());

            request.SetSalary(salary);

            var response = _calcPaymentValidatorService.Validate(request);

            Assert.True(response.Success);
            Assert.Empty(response.Messages);
        }

        [Fact]
        public void PaymentValidator_IsNotValid()
        {
            var taxConfiguration = new TaxConfiguration();
            var request = new CalcPaymentRequest();
            var salary = decimal.Parse(_faker.Finance.Amount(0, 1099).ToString());

            request.SetSalary(salary);

            var response = _calcPaymentValidatorService.Validate(request);

            Assert.False(response.Success);
            Assert.NotEmpty(response.Messages);
            Assert.Single(response.Messages);
            Assert.Equal(response.Messages.FirstOrDefault(), string.Format(Messages.MinimumSalaryValidation, taxConfiguration.MinimumSalary));
        }
    }
}
