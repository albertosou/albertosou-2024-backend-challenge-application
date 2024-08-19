using AlbertoSouza.AppBackendChallenge.Domain;
using AlbertoSouza.AppBackendChallenge.Ports;

namespace AlbertoSouza.AppBackendChallenge.Adapters;

public class JwtValidationService : IJwtValidationService
{
    public (bool isValid, string validationMessage) Validate(string jwt)
    {
        return JwtValidator.ValidateJwt(jwt);
    }
}
