using FV.PaymentCalculator.Core.DTOs;
using FV.PaymentCalculator.Core.Interfaces;
using FV.PaymentCalculator.Core.Utils;
using System.Collections.Generic;
using System.Linq;

namespace FV.PaymentCalculator.Core.Services
{
    /* 
     * Utilizado o princípio do Aberto Fechado (OCP):       
     * - Com a criação desta classe abstrata foi possível implementar diferentes calculos de impostos sem que um impacte o outro (IRRF e INSS);
    */

    /*
     * OCP trabalha em conjunto com o LSP, basicamente validando se as abtrações realizadas no OPC estão fazendo sentido
     */

    public abstract class CalcService : ICalcService
    {
        public abstract void Calculate(CalcPaymentRequest calcPaymentRequest, CalcPaymentResponse response);

        protected void CalcTaxByRange(double salary, TaxItem taxItem, List<TaxItem> taxItens, Dictionary<double, double> calcValues)
        {
            if (salary >= taxItem.Min && salary <= taxItem.Max)
            {
                var sumSalaryRange = taxItens
                    .Where(x => x.Order < taxItem.Order)
                    .Sum(x => x.SalaryRange);

                var value = salary - sumSalaryRange;
                value = value > taxItem.SalaryRange ? taxItem.SalaryRange : value;

                calcValues.Add(taxItem.Ref, taxItem.Free ? 0 : value);
            }
            else if (salary > taxItem.Max)
            {
                var value = taxItem.SalaryRange;
                if (value == 0)
                {
                    var sumSalaryRange = taxItens
                        .Where(x => x.Order < taxItem.Order)
                        .Sum(x => x.SalaryRange);

                    value = salary - sumSalaryRange;
                }

                calcValues.Add(taxItem.Ref, taxItem.Free ? 0 : value);
            }
        }
    }
}
