using System.IdentityModel.Tokens.Jwt;
using Jwtil.Core.Constants;
using Jwtil.Core.Models;
using Microsoft.IdentityModel.Tokens;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace Jwtil.Core.Services;

/// <summary>
///     Class <c>DefaultJwtDecoder</c> decodes a JSON Web Token using <c>System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler</c>.
/// </summary>
public class DefaultJwtDecoder : IJwtDecoder
{
  private readonly JwtSecurityTokenHandler _handler;

  public DefaultJwtDecoder(JwtSecurityTokenHandler handler)
  {
    _handler = handler;
  }

  /// <summary>
  ///     Decodes a JSON Web Token.
  /// </summary>
  /// <param name="token">The JSON Web Token.</param>
  /// <returns>
  ///     A decoded JSON Web Token.
  /// </returns>
  public async Task<DecodedToken> DecodeAsync(string token)
  {
    try {
      var securityToken = _handler.ReadJwtToken(token);
      return new DecodedToken 
      {
        Header = securityToken.Header.SerializeToJson(),
        Payload = securityToken.Payload.SerializeToJson(),
        Verified = await VerifyAsync(securityToken)
      };
    }
    catch (ArgumentException)
    {
      throw new ArgumentException("The <token> argument is an invalid JSON Web Token.");
    }
  }

  private async Task<bool> VerifyAsync(JwtSecurityToken token, CancellationToken cancellationToken = default) 
  {
    try {
      if (string.IsNullOrEmpty(token.Issuer)) throw new ArgumentException("The 'iss' claim is empty.");
      var openIdConfiguration = await OpenIdConnectConfigurationRetriever.GetAsync(
        token.Issuer + OidcConstants.DiscoveryEndpoint, cancellationToken);
      var key = openIdConfiguration.JsonWebKeySet.GetSigningKeys().First(key => key.KeyId == token.Header.Kid);

      var validationParameters = new TokenValidationParameters
      {
        IssuerSigningKey = key,
        ValidateAudience = true,
        ValidateIssuer = true,
        ValidateIssuerSigningKey = true,
        ValidateLifetime = true,
      };

      await _handler.ValidateTokenAsync(token.RawData, validationParameters);
      return true;
    }
    catch (Exception)
    {
      return false;
    }
  }
}
