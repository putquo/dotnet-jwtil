using Jwtil.Core.Models;

namespace Jwtil.Core.Writers;

/// <summary>
///     Interface <c>IJwtWriter</c> describes a generic writer capable of writing JSON Web Tokens to console.
/// </summary>
public interface IJwtWriter
{
  /// <summary>
  ///     Writes a decoded JSON Web Token to console.
  /// </summary>
  /// <param name="token">The decoded JSON Web Token.</param>
  void Write(DecodedToken token);
}
