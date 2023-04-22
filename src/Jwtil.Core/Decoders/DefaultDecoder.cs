using System.IdentityModel.Tokens.Jwt;

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
  /// <param name="jwt">The JSON Web Token.</param>
  /// <returns>
  ///     A tuple with the serialized JSON header and payload.
  /// </returns>
  public Tuple<string, string> Decode(string jwt)
  {
    var token = _handler.ReadJwtToken(jwt);
    return Tuple.Create(token.Header.SerializeToJson(), token.Payload.SerializeToJson());
  }
}
