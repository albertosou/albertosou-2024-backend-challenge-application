﻿using AlbertoSouza.BackendChallengeApplication.Ports;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Text.RegularExpressions;

namespace AlbertoSouza.BackendChallengeApplication.Api.Controllers;

[Route("api/[controller]")]
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
    [HttpGet]
    public IActionResult GetValidateJwt(string jwt)
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