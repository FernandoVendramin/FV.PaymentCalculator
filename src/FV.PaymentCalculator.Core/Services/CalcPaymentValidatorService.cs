using FV.PaymentCalculator.Core.DTOs;
using FV.PaymentCalculator.Core.Interfaces;
using FV.PaymentCalculator.Core.Utils;

namespace FV.PaymentCalculator.Core.Services
{
    public class CalcPaymentValidatorService : ICalcPaymentValidatorService
    {
        private readonly TaxConfiguration _taxConfiguration;

        public CalcPaymentValidatorService()
        {
            _taxConfiguration = new TaxConfiguration();
        }

        public CalcPaymentResponse Validate(CalcPaymentRequest request)
        {
            var response = new CalcPaymentResponse();

            ValidateMinimumSalary(request, response);
            ValidateDiscount(request, response);

            return response;
        }

        private void ValidateMinimumSalary(CalcPaymentRequest request, CalcPaymentResponse response)
        {
            if (request.Salary < _taxConfiguration.MinimumSalary)
                response.SetMessage(string.Format(Messages.MinimumSalaryValidation, _taxConfiguration.MinimumSalary));
        }

        private void ValidateDiscount(CalcPaymentRequest request, CalcPaymentResponse response)
        {
            if (request.Salary < request.OtherDiscounts)
                response.Messages.Add(Messages.DiscountValidation);

            if (request.Salary < request.HealthCareDiscount)
                response.Messages.Add(Messages.DiscountValidation);
        }
    }
}
