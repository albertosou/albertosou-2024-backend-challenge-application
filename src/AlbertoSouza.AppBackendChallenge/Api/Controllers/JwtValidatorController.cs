using AlbertoSouza.AppBackendChallenge.Ports;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AlbertoSouza.AppBackendChallenge.Api.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class JwtValidatorController : ControllerBase
    {
        private readonly ILogger<JwtValidatorController> _logger;
        private readonly IJwtValidationService _jwtValidationService;

        public JwtValidatorController(ILogger<JwtValidatorController> logger, IJwtValidationService jwtValidationService)
        {
            _logger = logger;
            _jwtValidationService = jwtValidationService;
        }

        /// <summary>
        /// Valida um JWT (JSON Web Token) fornecido.
        /// </summary>
        /// <param name="jwt">O JWT a ser validado.</param>
        /// <returns>Um valor booleano indicando se o JWT é válido ou não.</returns>
        [HttpGet]
        [SwaggerOperation(
            Summary = "Valida um JWT (JSON Web Token)",
            Description = "Verifica se o JWT fornecido é válido.",
            OperationId = "ValidateJwt",
            Tags = new[] { "JWT Validator" })]
        [SwaggerResponse(200, "Retorna um valor booleano indicando se o JWT é válido ou não.")]
        public IActionResult GetValidateJwt(
            [SwaggerParameter("O JWT a ser validado.", Required = true)]
            string jwt)
        {
            try
            {
                var (isValid, validationMessage) = _jwtValidationService.Validate(jwt);
                _logger.LogDebug(validationMessage);
                return Ok(isValid);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao validar o JWT: {ex.Message}");
                return Ok(false);
            }
        }
    }
}
