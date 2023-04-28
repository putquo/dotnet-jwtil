using Jwtil.Core.Models;
using Spectre.Console;
using Spectre.Console.Json;

namespace Jwtil.Core.Writers;

/// <summary>
///     Class <c>DefaultJwtWriter</c> writes a decoded JSON Web Token to console using <c>Spectre.Console.AnsiConsole</c>.
/// </summary>
public class DefaultJwtWriter : IJwtWriter
{
  /// <summary>
  ///     Writes a decoded JSON Web Token to console.
  /// </summary>
  /// <param name="token">The decoded JSON Web Token.</param>
  public void Write(DecodedToken token)
  {
    var verifiedText = token.Verified ? Emoji.Known.ThumbsUp : Emoji.Known.ThumbsDown;
    AnsiConsole.Write(
      new Panel(new JsonText(token.Header))
        .Header("Header " + verifiedText)
        .Collapse()
        .RoundedBorder()
    );
    AnsiConsole.Write(
      new Panel(new JsonText(token.Payload))
        .Header("Payload " + verifiedText)
        .Collapse()
        .RoundedBorder()
    );
  }
}
