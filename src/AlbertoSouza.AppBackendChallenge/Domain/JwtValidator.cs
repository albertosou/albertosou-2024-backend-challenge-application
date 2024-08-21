using System.IdentityModel.Tokens.Jwt;
using System.Text.RegularExpressions;

namespace AlbertoSouza.AppBackendChallenge.Domain;

public class JwtValidator
{
    public static readonly string MSG_VALID_TOKEN = "Token JWT válido";
    public static readonly string MSG_INVALID_TOKEN = "Token JWT inválido";
    public static readonly string MSG_INVALID_TOKEN_CLAIM_COUNT = "O token deve conter exatamente 3 claims";
    public static readonly string MSG_INVALID_TOKEN_CLAIM_CONTAINS = "As claims Name, Role e Seed são obrigatórias";
    public static readonly string MSG_INVALID_TOKEN_ROLE_CONTAINS = "A claim Role deve ser Admin, Member ou External";
    public static readonly string MSG_INVALID_TOKEN_NAME_NUMBERS = "A claim Name não pode conter números";
    public static readonly string MSG_INVALID_TOKEN_NAME_LENGTH = "A claim Name não pode ter mais de 256 caracteres";
    public static readonly string MSG_INVALID_TOKEN_SEED_PRIME = "A claim Seed deve ser um número primo";

    public static (bool IsValid, string ValidationMessage) ValidateJwt(string jwt)
    {

        var formatValidation = GetTokenAndValidateFormat(jwt);
        if (!formatValidation.IsValid || formatValidation.token == null)
        {
            return (formatValidation.IsValid, formatValidation.ValidationMessage);
        }

        var token = formatValidation.token;

        var acceptValidation = ValidateAccept(token);
        if (!acceptValidation.IsValid)
        {
            return acceptValidation;
        }

        var nameValidation = ValidateName(token);
        if (!nameValidation.IsValid)
        {
            return nameValidation;
        }

        var roleValidation = ValidateRole(token);
        if (!roleValidation.IsValid)
        {
            return roleValidation;
        }

        var seedValidation = ValidateSeed(token);
        if (!seedValidation.IsValid)
        {
            return seedValidation;
        }

        return (true, MSG_VALID_TOKEN);
    }
    public static (bool IsValid, string ValidationMessage, JwtSecurityToken? token) GetTokenAndValidateFormat(string jwt)
    {
        try
        {
            var handler = new JwtSecurityTokenHandler();

            if (handler.CanReadToken(jwt))
            {
                var token = handler.ReadJwtToken(jwt);
                return (true, string.Empty, token);
            }
        }
        catch
        {
            return (false, MSG_INVALID_TOKEN, default(JwtSecurityToken));
        }
        return (false, MSG_INVALID_TOKEN, default(JwtSecurityToken));

    }
    public static (bool IsValid, string ValidationMessage) ValidateAccept(JwtSecurityToken token)
    {
        if (token.Claims.Count() != 3)
        {
            return (false, MSG_INVALID_TOKEN_CLAIM_COUNT);
        }

        var validClaims = new[] { "Name", "Role", "Seed" };

        if (token.Claims.Any(el => !validClaims.Contains(el.Type) || string.IsNullOrEmpty(el.Value)))
        {
            return (false, MSG_INVALID_TOKEN_CLAIM_CONTAINS);
        }

        return (true, string.Empty);
    }

    public static (bool IsValid, string ValidationMessage) ValidateName(JwtSecurityToken token)
    {
        var name = token.Claims.First(c => c.Type == "Name").Value;

        if (Regex.IsMatch(name, @"\d"))
        {
            return (false, MSG_INVALID_TOKEN_NAME_NUMBERS);
        }

        if (name.Length > 256)
        {
            return (false, MSG_INVALID_TOKEN_NAME_LENGTH);
        }

        return (true, string.Empty);
    }

    public static (bool IsValid, string ValidationMessage) ValidateRole(JwtSecurityToken token)
    {
        var role = token.Claims.First(c => c.Type == "Role").Value;
        var validRoles = new[] { "Admin", "Member", "External" };

        if (!validRoles.Contains(role))
        {
            return (false, MSG_INVALID_TOKEN_ROLE_CONTAINS);
        }

        return (true, string.Empty);
    }

    public static (bool IsValid, string ValidationMessage) ValidateSeed(JwtSecurityToken token)
    {
        var seed = token.Claims.First(c => c.Type == "Seed").Value;

        if (!int.TryParse(seed, out int seedValue) || !IsPrime(seedValue))
        {
            return (false, MSG_INVALID_TOKEN_SEED_PRIME);
        }

        return (true, string.Empty);
    }

    public static bool IsPrime(int number)
    {
        if (number <= 1) return false;
        if (number == 2) return true;
        if (number % 2 == 0) return false;

        var boundary = (int)Math.Floor(Math.Sqrt(number));

        for (int i = 3; i <= boundary; i += 2)
        {
            if (number % i == 0) return false;
        }

        return true;
    }
}