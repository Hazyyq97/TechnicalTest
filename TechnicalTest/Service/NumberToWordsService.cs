using TechnicalTest.Service.IService;

namespace TechnicalTest.Service
{
    public class NumberToWordsService : INumberToWordsService
    {
        private static readonly string[] Units =
        {
            "Zero", "One", "Two", "Three", "Four", "Five",
            "Six", "Seven", "Eight", "Nine", "Ten", "Eleven",
            "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen",
            "Seventeen", "Eighteen", "Nineteen"
        };

        private static readonly string[] Tens =
        {
            "", "", "Twenty", "Thirty", "Forty", "Fifty",
            "Sixty", "Seventy", "Eighty", "Ninety"
         };

        private static readonly string[] Scales =
        {
            "", "Thousand", "Million"
        };

        public string ConvertNumberToWords(double number)
        {
            int integerPart = (int)number;
            int fractionalPart = (int)Math.Round((number - integerPart) * 100);

            string result = $"{ConvertToWords(integerPart)} Dollar";
            if (fractionalPart > 0)
            {
                result += $" And {ConvertToWords(fractionalPart)} Cent";
            }

            return result + ".";
        }

        private string ConvertToWords(int number)
        {
            if (number == 0) return Units[0];
            if (number < 20) return Units[number];
            if (number < 100) return Tens[number / 10] + (number % 10 > 0 ? " " + ConvertToWords(number % 10) : "");
            if (number < 1000) return Units[number / 100] + " Hundred" + (number % 100 > 0 ? " And " + ConvertToWords(number % 100) : "");

            for (int i = 0; i < Scales.Length; i++)
            {
                int unitValue = (int)Math.Pow(1000, i + 1);
                if (number < unitValue)
                {
                    return ConvertToWords(number / (unitValue / 1000)) + " " + Scales[i] +
                           (number % (unitValue / 1000) > 0 ? " " + ConvertToWords(number % (unitValue / 1000)) : "");
                }
            }

            return ("Number is too large to convert.");
        }
    }
}
