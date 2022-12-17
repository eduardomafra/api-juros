using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Granito.Utilities.Services
{
    public interface IInterestRateService
    {
        Task<double> GetInterestRate();
    }
}
