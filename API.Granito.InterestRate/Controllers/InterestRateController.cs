using Microsoft.AspNetCore.Mvc;

namespace API.Granito.InterestRate.Controllers
{
    /// <summary>
    /// Controller para consultar a taxa de juros.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class InterestRateController : ControllerBase
    {
        private readonly ILogger<InterestRateController> _logger;

        public InterestRateController(ILogger<InterestRateController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Retorna a taxa de juros
        /// </summary>
        /// <returns>Taxa de juros</returns>
        /// <response code="200">Taxa de juros foi obtida com sucesso.</response>
        [HttpGet]
        [Route("/taxadejuros")]
        public async Task<IActionResult> GetRate()
        {
            return Ok(0.01);
        }
    }
}
