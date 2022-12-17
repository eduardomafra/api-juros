using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Granito.Utilities.Calculator
{
    public class InterestCalculator : IInterestCalculator
    {
        public decimal CalculateInterest(decimal value, int months, double interestRate)
        {
            var power = Math.Pow((1 + interestRate), months);
            var result = (decimal)power * value;
            return Math.Truncate(100 * result) / 100;
        }
    }
}
