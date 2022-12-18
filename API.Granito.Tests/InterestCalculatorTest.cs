using Xunit;

namespace API.Granito.Tests
{
    public class InterestCalculatorTest
    {
        private Utilities.Calculator.InterestCalculator _interestCalculator;
        
        public InterestCalculatorTest()
        {
            _interestCalculator= new Utilities.Calculator.InterestCalculator();
        }

        [Fact]
        public void InterestCalculator_CalculateInterest()
        {
            var result = _interestCalculator.CalculateInterest(122, 44, 0.01);

            Assert.Equal(189.01m, result);
        }
    }
}
