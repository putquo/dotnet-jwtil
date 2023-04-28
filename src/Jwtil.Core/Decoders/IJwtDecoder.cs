using Jwtil.Core.Models;

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
  ///     A decoded JSON Web Token.
  /// </returns>
  Task<DecodedToken> DecodeAsync(string token);
}
