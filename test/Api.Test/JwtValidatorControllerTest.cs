using AlbertoSouza.BackendChallengeApplication.Api.Controllers;
using AlbertoSouza.BackendChallengeApplication.Ports;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NSubstitute;

namespace AlbertoSouza.BackendChallengeApplication.Api.Test
{
    public class JwtValidatorControllerTest
    {
        private readonly ILogger<JwtValidatorController> _logger = Substitute.For<ILogger<JwtValidatorController>>();
        private readonly IJwtValidationService _jwtValidationService = Substitute.For<IJwtValidationService>();

        [Fact]
        public void GiveOneJwtValidData_WhenValidateJwt_ThenShouldReturnIsValidAndSuccessMessage()
        {
            // Arrange / Give
            var jwt = "eyJhbGciOiJIUzI1NiJ9.eyJSb2xlIjoiQWRtaW4iLCJTZWVkIjoiNzg0MSIsIk5hbWUiOiJUb25pbmhvIEFyYXVqbyJ9.QY05sIjtrcJnP533kQNk8QXcaleJ1Q01jWY_ZzIZuAg";
            _jwtValidationService.Validate(jwt).Returns((true, "sucesso"));

            var sut = new JwtValidatorController(_logger, _jwtValidationService);

            // Act / When
            var data = (ObjectResult)sut.GetValidateJwt(jwt);

            // Assert / Then
            Assert.Equal(true, data.Value);
            _jwtValidationService.Received(1).Validate(jwt);
        }
    }
}