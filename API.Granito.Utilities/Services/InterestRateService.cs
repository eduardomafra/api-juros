using API.Granito.Utilities.Helper;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Granito.Utilities.Services
{
    public class InterestRateService : IInterestRateService
    {
        private IOptions<APISettingsModel> _config;

        public InterestRateService(IOptions<APISettingsModel> config)
        {
            _config= config;
        }

        public async Task<double> GetInterestRate()
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            using (var client = new HttpClient(clientHandler))
            {
                client.BaseAddress = new Uri(_config.Value.InterestRateAPIUrl);
                var response = await client.GetAsync("taxadejuros");
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var interestRate = double.Parse(result, System.Globalization.CultureInfo.InvariantCulture);
                    return interestRate;
                }
                else
                {
                    throw new Exception();
                }
            }
        }
    }
}
