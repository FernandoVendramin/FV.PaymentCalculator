using FV.PaymentCalculator.Core.DTOs;
using FV.PaymentCalculator.Core.Interfaces;
using FV.PaymentCalculator.Core.Services;
using FV.PaymentCalculator.Core.Utils;
using FV.PaymentCalculator.Facade;
using FV.PaymentCalculator.Facade.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace FV.PaymentCalculator.Console
{
    public class Program
    {
        // https://calculador.com.br/calculo/salario-liquido
        // https://www.calculadorafacil.com.br/trabalhista/calculo-salario-liquido
        // https://www.youtube.com/watch?v=wkCkBvUOeNg

        private static ServiceProvider _serviceProvider;

        public static void Main(string[] args)
        {
            LoadServiceProvider();

            var running = true;
            System.Console.ForegroundColor = ConsoleColor.White;
            System.Console.BackgroundColor = ConsoleColor.Black;
            System.Console.ResetColor();

            // while (running)
            // {
            System.Console.ForegroundColor = ConsoleColor.Blue;
            System.Console.WriteLine("**** Cálculo de Salário Liquido ****");
            System.Console.ResetColor();
            System.Console.WriteLine(" Digite uma das opções abaixo:");
            System.Console.WriteLine(" 1 - Calcular");
            System.Console.WriteLine(" 0 - Sair");
            System.Console.WriteLine("");
            System.Console.WriteLine("");
            var key = System.Console.ReadLine();

            switch (key)
            {
                case "0":
                    running = false; break;
                case "1":
                    GetCalculateParams(); break;
                default:
                    System.Console.Clear(); break;
            }

            // System.Console.Clear();
            // }
        }

        private static void LoadServiceProvider()
        {
            _serviceProvider = new ServiceCollection()
                .AddSingleton<ICalcPaymentFacade, CalcPaymentFacade>()
                .AddSingleton<ICalcPaymentValidatorService, CalcPaymentValidatorService>()
                .AddSingleton<ICalcINSSService, CalcINSSService>()
                .AddSingleton<ICalcIRRFService, CalcIRRFService>()
                .AddSingleton(new TaxConfiguration())
                .BuildServiceProvider();
        }

        private static void GetCalculateParams()
        {
            decimal decimalValue;

            var request = new CalcPaymentRequest();
            System.Console.WriteLine("Digite o valor do salário (Apenas números):");
            var salary = System.Console.ReadLine();
            if (decimal.TryParse(salary, out decimalValue))
                request.SetSalary(decimalValue);

            System.Console.WriteLine("Digite o valor de outros discontos:");
            var discount = System.Console.ReadLine();
            if (decimal.TryParse(discount, out decimalValue))
                request.SetOtherDiscounts(decimalValue);

            System.Console.WriteLine("Digite o valor do Plano de Saude:");
            var healthCare = System.Console.ReadLine();
            if (decimal.TryParse(healthCare, out decimalValue))
                request.SetHealthCareDiscount(decimalValue);

            if (request.Salary == 0)
            {
                System.Console.WriteLine("O Salário é obrigatório. Cálculo cancelado!");
            }
            else
            {
                var calcPaymentService = _serviceProvider.GetService<ICalcPaymentFacade>();
                var response = calcPaymentService.Calculate(request);

                if (response.Success)
                {

                    System.Console.ForegroundColor = ConsoleColor.Cyan;
                    System.Console.WriteLine("Resumo: ");
                    System.Console.ResetColor();
                    System.Console.WriteLine("");

                    System.Console.WriteLine(" ---------------------------------");
                    System.Console.WriteLine(String.Format("|{0,-17}|{1,-15}|", " Evento", " Descontos"));
                    System.Console.WriteLine(" ---------------------------------");

                    foreach (var item in response.Data.Discounts)
                    {
                        System.Console.WriteLine(
                            String.Format("|{0,-17}|{1,-15:C}|",
                            item.Key,
                            item.Value));
                    }
                    System.Console.WriteLine(" ---------------------------------");

                    System.Console.WriteLine("");

                    System.Console.ForegroundColor = ConsoleColor.Red;
                    System.Console.WriteLine($"Descontos: {String.Format("{0,-10:C}", response.Data.Discounts != null ? response.Data.Discounts.Sum(x => x.Value) : 0)}");
                    System.Console.ResetColor();

                    System.Console.ForegroundColor = ConsoleColor.Green;
                    System.Console.WriteLine($"Salário Líquido: {String.Format("{0,-10:C}", response.Data.Value)}");
                    System.Console.ResetColor();

                }
                else
                {
                    System.Console.ForegroundColor = ConsoleColor.Red;
                    System.Console.WriteLine("Falha ao calcular o salário. Mensagens:");
                    System.Console.ResetColor();
                    foreach (var message in response.Messages)
                    {
                        System.Console.WriteLine(message);
                    }
                }
            }

            System.Console.WriteLine("");
            System.Console.WriteLine("Pressione uma tecla para continuar...");
            System.Console.ReadLine();
        }
    }
}
