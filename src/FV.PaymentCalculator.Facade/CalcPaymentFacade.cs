using FV.PaymentCalculator.Core.DTOs;
using FV.PaymentCalculator.Core.Interfaces;
using FV.PaymentCalculator.Core.Models;
using FV.PaymentCalculator.Core.Services;
using FV.PaymentCalculator.Core.Utils;
using FV.PaymentCalculator.Facade.Interfaces;
using System.Collections.Generic;

namespace FV.PaymentCalculator.Facade
{
    public class CalcPaymentFacade : ICalcPaymentFacade
    {
        private readonly ICalcPaymentValidatorService _calcPaymentValidatorService;

        /* 
         * DIP: Utilizado para referenciar aqui a dependencia de uma abstração e não da classe concreta 
         */
        public CalcPaymentFacade(
            ICalcPaymentValidatorService calcPaymentValidatorService)
        {
            _calcPaymentValidatorService = calcPaymentValidatorService;
        }

        /*
         * SRP: O unico motivo de alteração nesta classe seria pelas regras do próprio calculo do salário, 
         * como por exemplo, se entrar um novo imposto a ser descontado.
         * Se houver necessidade de alterar o calculo do INSS por exemplo, não será necessário alterarmos o método Calculate abaixo,
         * apenas o método Calculate do CalcINSSService. 
         */

        public CalcPaymentResponse Calculate(CalcPaymentRequest request)
        {
            var response = _calcPaymentValidatorService.Validate(request);
            if (!response.Success)
                return response;


            var salary = new Holerite(request.Salary)
                .AddDiscount(new CalcINSSService())
                .AddDiscount(new CalcIRRFService())
                .AddDiscount(new CalcHealthCareDiscountService(request.HealthCareDiscount))
                .AddDiscount(new CalcOtherDiscountsService(request.OtherDiscounts))
                .GetHolerite();

            response.SetData(salary);

            return response;
        }
    }
}
