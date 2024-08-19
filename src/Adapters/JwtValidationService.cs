using AlbertoSouza.BackendChallengeApplication.Domain;
using AlbertoSouza.BackendChallengeApplication.Ports;

namespace AlbertoSouza.BackendChallengeApplication.Adapters;

public class JwtValidationService : IJwtValidationService
{
    public (bool isValid, string validationMessage) Validate(string jwt)
    {
        return JwtValidator.ValidateJwt(jwt);
    }
}
