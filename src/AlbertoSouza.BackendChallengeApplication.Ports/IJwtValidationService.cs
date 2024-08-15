namespace AlbertoSouza.BackendChallengeApplication.Ports;

public interface IJwtValidationService
{
    (bool isValid, string validationMessage) Validate(string jwt);
}
