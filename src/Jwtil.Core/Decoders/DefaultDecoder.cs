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
  /// <param name="token">The JSON Web Token.</param>
  /// <returns>
  ///     A tuple with the serialized JSON header and payload.
  /// </returns>
  public Tuple<string, string> Decode(string token)
  {
    var t = _handler.ReadJwtToken(token);
    return Tuple.Create(t.Header.SerializeToJson(), t.Payload.SerializeToJson());
  }
}
