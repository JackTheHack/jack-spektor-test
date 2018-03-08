using System;
using System.Linq;
using System.Text;
using Humanizer;

namespace NumberHumanizer.BusinessLogic
{
    public class DecimalNumberHumanizer : INumberHumanizer
    {
        public string Transform(string number)
        {
            if (string.IsNullOrEmpty(number))
            {
                throw new ArgumentException("Number can't be empty.");
            }

            string[] numberParts = number.Split(',', '.').ToArray();

            int numberValue = 0;
            if (!int.TryParse(numberParts[0], out numberValue))
            {
                throw new ArgumentException("Please provide a valid number. Number must be between -2147483647 and 2147483647.");
            }

            int decimalValue = 0;

            if (numberParts.Length > 1)
            {
                if (string.IsNullOrEmpty(numberParts[1]))
                {
                    throw new ArgumentException("Decimal number part can't be empty.");
                }

                //Normalise decimal part to 2 points
                var normalisedDecimalPart = numberParts[1].Length > 2 ? numberParts[1].Substring(0, 2) : numberParts[1];
                normalisedDecimalPart = normalisedDecimalPart.Length == 1  ? normalisedDecimalPart + "0" : normalisedDecimalPart;

                if (!int.TryParse(normalisedDecimalPart, out decimalValue))
                {
                    throw new ArgumentException("Decimal argument is not a number.");
                }
            }
            
            var result = new StringBuilder();
            result.Append(numberValue.ToWords());
            result.Append(numberValue != 1 ? " dollars" : " dollar");
            if (decimalValue > 0)
            {
                result.Append(" and ");
                result.Append(decimalValue.ToWords());
                result.Append(decimalValue > 1 ? " cents" : " cent");
            }

            return result.ToString();
        }
    }
}
