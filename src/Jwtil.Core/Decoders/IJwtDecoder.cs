namespace Jwtil.Core.Services;

/// <summary>
///     Interface <c>IJwtDecoder</c> describes a generic decoder capable of decoding JSON Web Tokens.
/// </summary>
public interface IJwtDecoder
{
  /// <summary>
  ///     Decodes a JSON Web Token.
  /// </summary>
  /// <param name="token">The JSON Web Token.</param>
  /// <returns>
  ///     A tuple with the serialized JSON header and payload.
  /// </returns>
  Tuple<string, string> Decode(string token);
}
