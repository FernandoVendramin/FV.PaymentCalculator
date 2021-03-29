using FV.PaymentCalculator.Core.DTOs;
using FV.PaymentCalculator.Core.Factory;
using FV.PaymentCalculator.Core.Interfaces;
using FV.PaymentCalculator.Core.Observer;
using FV.PaymentCalculator.Core.Utils;
using FV.PaymentCalculator.Facade.Interfaces;
using System.Collections.Generic;

namespace FV.PaymentCalculator.Facade
{
    public class CalcPaymentFacade : ICalcPaymentFacade
    {
        private readonly ICalcPaymentValidatorService _calcPaymentValidatorService;
        private readonly ICalcServiceFactory _calcServiceFactory;

        /* 
         * DIP: Utilizado para referenciar aqui a dependencia de uma abstração e não da classe concreta 
         */
        public CalcPaymentFacade(
            ICalcPaymentValidatorService calcPaymentValidatorService,
            ICalcServiceFactory calcServiceFactory)
        {
            _calcPaymentValidatorService = calcPaymentValidatorService;
            _calcServiceFactory = calcServiceFactory;
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

            var inssService = _calcServiceFactory.GetCalcService(CalcEnum.INSS);
            var irrfService = _calcServiceFactory.GetCalcService(CalcEnum.IRRF);
            var otherDiscountsService = _calcServiceFactory.GetCalcService(CalcEnum.Others);

            var calculateSubject = new CalculateSubject();
            calculateSubject.Attach(inssService);
            calculateSubject.Attach(irrfService);
            calculateSubject.Attach(otherDiscountsService);

            var itens = new List<CalcPaymentItem>();
            itens.Add(new CalcPaymentItem(Messages.RawSalaryItem, 0, request.Salary, 0));
            response.SetData(new CalcPaymentData(itens));

            calculateSubject.Execute(request, response);

            return response;
        }
    }
}
