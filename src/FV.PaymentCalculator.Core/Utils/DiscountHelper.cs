namespace FV.PaymentCalculator.Core.Utils
{
    public static class DiscountHelper
    {
        private static string INSS = "INSS - {0} %";
        private static string IRRF = "IRRF - {0} %";
        private static string HealthCare = "Health Care";
        private static string Others = "Others";

        public static string GetINSSText(decimal value) => string.Format(INSS, value);
        public static string GetIRRFText(decimal value) => string.Format(IRRF, value);
        public static string GetHealthCareText => HealthCare;
        public static string GetOthersText => Others;
    }
}
