namespace FV.PaymentCalculator.Core.Utils
{
    public static class Messages
    {
        public static string RawSalaryItem = "Salário Bruto";
        public static string INSSItem = "INSS";
        public static string IRRFItem = "IRRF";
        public static string OtherDiscountItem = "Outros descontos";

        public static string MinimumSalaryValidation = "Salário Bruto deve ser maior que salário mínimo. (Salário mínimo vigente: R$ {0})";
        public static string DiscountValidation = "O valor do desconto não pode ser superior ao valor do salário.";
    }
}
