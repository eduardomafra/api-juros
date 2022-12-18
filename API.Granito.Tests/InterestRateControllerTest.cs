using API.Granito.InterestRate.Controllers;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace API.Granito.Tests
{
    public class InterestRateControllerTest
    {
        private HttpClient _client;

        public InterestRateControllerTest()
        {
            var webAppFactory = new WebApplicationFactory<InterestRateController>();
            _client = webAppFactory.CreateDefaultClient();
        }

        [Fact]
        public async Task InterestCalculator_CalculateInterest_GetRate()
        {
            var response = await _client.GetAsync("taxadejuros");
            var stringResult = await response.Content.ReadAsStringAsync();

            Assert.Equal("0.01", stringResult);
        }
    }
}
