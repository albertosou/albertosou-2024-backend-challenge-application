namespace AlbertoSouza.AppBackendChallenge.Ports;

public interface IJwtValidationService
{
    (bool isValid, string validationMessage) Validate(string jwt);
}
