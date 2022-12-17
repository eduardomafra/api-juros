using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Granito.Utilities.Calculator
{
    public interface IInterestCalculator
    {
        decimal CalculateInterest(decimal value, int months, double interestRate);
    }
}
