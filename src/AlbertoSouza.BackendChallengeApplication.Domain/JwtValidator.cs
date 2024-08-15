using System.IdentityModel.Tokens.Jwt;
using System.Text.RegularExpressions;

namespace AlbertoSouza.BackendChallengeApplication.Domain;

public class JwtValidator
{
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

        return (true, "Token JWT válido");
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
            return (false, "Token JWT inválido", default(JwtSecurityToken));
        }
        return (false, "Token JWT inválido", default(JwtSecurityToken));

    }
    public static (bool IsValid, string ValidationMessage) ValidateAccept(JwtSecurityToken token)
    {
        if (token.Claims.Count() != 3)
        {
            return (false, "O token deve conter exatamente 3 claims");
        }

        var validClaims = new[] { "Name", "Role", "Seed" };
        var formatClaims = string.Join(", ", validClaims);

        if (token.Claims.Any(el => !validClaims.Contains(el.Type) || string.IsNullOrEmpty(el.Value)))
        {
            return (false, $"As claims {formatClaims} são obrigatórias");
        }

        return (true, string.Empty);
    }

    public static (bool IsValid, string ValidationMessage) ValidateName(JwtSecurityToken token)
    {
        var name = token.Claims.First(c => c.Type == "Name").Value;

        if (Regex.IsMatch(name, @"\d"))
        {
            return (false, "A claim Name não pode conter números");
        }

        if (name.Length > 256)
        {
            return (false, "A claim Name não pode ter mais de 256 caracteres");
        }

        return (true, string.Empty);
    }

    public static (bool IsValid, string ValidationMessage) ValidateRole(JwtSecurityToken token)
    {
        var role = token.Claims.First(c => c.Type == "Role").Value;
        var validRoles = new[] { "Admin", "Member", "External" };

        if (!validRoles.Contains(role))
        {
            return (false, "A claim Role deve ser Admin, Member ou External");
        }

        return (true, string.Empty);
    }

    public static (bool IsValid, string ValidationMessage) ValidateSeed(JwtSecurityToken token)
    {
        var seed = token.Claims.First(c => c.Type == "Seed").Value;

        if (!int.TryParse(seed, out int seedValue) || !IsPrime(seedValue))
        {
            return (false, "A claim Seed deve ser um número primo");
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