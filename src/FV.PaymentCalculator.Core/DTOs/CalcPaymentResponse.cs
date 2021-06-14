using FV.PaymentCalculator.Core.DTOs.Base;
using FV.PaymentCalculator.Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace FV.PaymentCalculator.Core.DTOs
{
    public class CalcPaymentResponse : ResponseBase
    {
        public CalcPaymentResponse()
        {
            Messages = new List<string>();
        }

        public CalcPaymentResponse(Salary data)
        {
            Data = data;
            Messages = new List<string>();
        }

        public Salary Data { get; private set; }
        public bool Success { get => Messages == null || Messages.Count() == 0; }
        public List<string> Messages { get; private set; }

        public void SetData (Salary data)
        {
            Data = data;
        }

        public void SetMessages(List<string> messages)
        {
            Messages = messages;
        }

        public void SetMessage(string message)
        {
            Messages.Add(message);
        }
    }
}
