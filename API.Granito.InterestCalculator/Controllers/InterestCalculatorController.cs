using API.Granito.Utilities.Calculator;
using API.Granito.Utilities.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Granito.InterestCalculator.Controllers
{
    /// <summary>
    /// Controller para realizar cálculo de juros.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class InterestCalculatorController : ControllerBase
    {
        private readonly ILogger<InterestCalculatorController> _logger;

        private readonly IInterestRateService _interestRateService;

        private readonly IInterestCalculator _interestCalculator;
        public InterestCalculatorController(ILogger<InterestCalculatorController> logger, IInterestRateService interestRateService, IInterestCalculator interestCalculator)
        {
            _logger = logger;
            _interestRateService = interestRateService;
            _interestCalculator = interestCalculator;
        }

        /// <summary>
        /// Faz o cálculo de juros com base no valor e na quantidade de meses
        /// </summary>
        /// <param name="valorInicial">Valor inicial para o cálculo</param>
        /// <param name="meses">Quantidade de meses</param>
        /// <returns>O valor inicial somado ao juros, o valor inicial e a quantidade de meses</returns>
        /// <response code="200">O cálculo foi feito com sucesso.</response>
        /// <response code="400">Os parâmetros obrigatórios estavam ausentes ou inválidos.</response>
        /// <response code="500">Ocorreu um erro ao calcular o juros.</response>
        [HttpGet]
        [Route("/calculajuros")]
        public async Task<IActionResult> CalculateInterest(decimal valorInicial, int meses)
        {
            if (valorInicial <= 0)
                return BadRequest(@"Parâmetro ""valor inicial"" inválido");

            if (meses <= 0)
                return BadRequest(@"Parâmetro ""meses"" inválido");
                        
            try
            {
                double interestRate = await _interestRateService.GetInterestRate();
                var result = _interestCalculator.CalculateInterest(valorInicial, meses, interestRate);
                return Ok(result);
                //return Ok(new CalculatedInterestResponseDTO()
                //{
                //    ValueWithInterest = result
                //});
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro ao processar a requisição");
            }

        }

        /// <summary>
        /// Exibe a URL do repositório deste projeto no Github
        /// </summary>
        /// <returns>URL do repositório deste projeto no Github</returns>
        /// <response code="200">A URL foi retornada com sucesso.</response>
        [HttpGet]
        [Route("/showmethecode")]
        public IActionResult ShowMeTheCode()
        {
            return Ok("https://github.com/eduardomafra/api-juros-granito");
        }
    }
}
