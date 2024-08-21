using AlbertoSouza.AppBackendChallenge.Domain;

namespace AlbertoSouza.AppBackendChallenge.Adapters.Test
{
    public class JwtValidationServiceTest
    {
        [Fact]
        public void GiveOneJwtValidData_WhenValidateJwt_ThenShouldReturnIsValidAndSuccessMessage()
        {
            // Arrange / Give
            var jwt = "eyJhbGciOiJIUzI1NiJ9.eyJSb2xlIjoiQWRtaW4iLCJTZWVkIjoiNzg0MSIsIk5hbWUiOiJUb25pbmhvIEFyYXVqbyJ9.QY05sIjtrcJnP533kQNk8QXcaleJ1Q01jWY_ZzIZuAg";
            var sut = new JwtValidationService();
            var expectedMessage = JwtValidator.MSG_VALID_TOKEN;

            // Act / When
            var result = sut.Validate(jwt);

            // Assert / Then
            Assert.True(result.isValid);
            Assert.Equal(expectedMessage, result.validationMessage);
        }
    }
}