namespace Jwtil.Core.Writers;

/// <summary>
///     Interface <c>IJwtWriter</c> describes a generic writer capable of writing JSON Web Tokens to console.
/// </summary>
public interface IJwtWriter
{
  /// <summary>
  ///     Writes a decoded JSON Web Token to console.
  /// </summary>
  /// <param name="header">The serialized header.</param>
  /// <param name="payload">The serialized payload.</param>
  void Write(string header, string payload);
}
