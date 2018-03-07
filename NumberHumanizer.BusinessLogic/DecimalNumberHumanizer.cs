using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Humanizer;

namespace NumberHumanizer.BusinessLogic
{
    public class DecimalNumberHumanizer : INumberHumanizer
    {
        public string Transform(string number)
        {
            int numberValue = 0;
            if (!int.TryParse(number, out numberValue))
            {
                throw new ArgumentException("Argument is not a number");

            }

            return numberValue.ToWords();
        }
    }
}
