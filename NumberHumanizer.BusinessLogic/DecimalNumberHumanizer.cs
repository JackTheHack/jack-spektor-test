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
                throw new ArgumentNullException(nameof(number));
            }

            string[] numberParts = number.Split(',', '.').ToArray();

            int numberValue = 0;
            if (!int.TryParse(numberParts[0], out numberValue))
            {
                throw new ArgumentException("Argument is not a number", nameof(number));
            }

            int decimalValue = 0;

            if (numberParts.Length > 1)
            {
                if (string.IsNullOrEmpty(numberParts[1]))
                {
                    throw new ArgumentNullException(nameof(number));
                }

                if (!int.TryParse(numberParts[1], out decimalValue))
                {
                    throw new ArgumentException("Decimal argument is not a number", nameof(number));
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
