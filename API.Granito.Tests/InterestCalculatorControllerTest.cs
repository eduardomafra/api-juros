using API.Granito.InterestCalculator.Controllers;
using API.Granito.Utilities.Services;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Xunit;

namespace API.Granito.Tests
{    
    public class InterestCalculatorControllerTest
    {
        private HttpClient _client;
        Mock<IInterestRateService> _interestRateServiceMock;
        public InterestCalculatorControllerTest()
        {
            _interestRateServiceMock = new Mock<IInterestRateService>();
            _interestRateServiceMock.Setup(x => x.GetInterestRate()).Returns(Task.FromResult(0.01));

            var webAppFactory = new WebApplicationFactory<InterestCalculatorController>();
            _client = webAppFactory.WithWebHostBuilder(
                builder => builder.ConfigureTestServices(
                    services => services.AddTransient(_ => _interestRateServiceMock.Object))
                ).CreateDefaultClient();
        }

        [Fact]
        public async Task InterestCalculator_CalculateInterest()
        {
            var response = await _client.GetAsync("calculajuros?valorInicial=122&meses=44");
            var stringResult = await response.Content.ReadAsStringAsync();

            Assert.Equal("189.01", stringResult);
        }

        [Fact]
        public async Task InterestCalculator_ShowMeTheCode()
        {
            var response = await _client.GetAsync("showmethecode");

            response.EnsureSuccessStatusCode();
        }


    }
}
