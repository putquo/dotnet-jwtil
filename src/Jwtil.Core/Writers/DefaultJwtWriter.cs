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
  /// <param name="header">The serialized header.</param>
  /// <param name="payload">The serialized payload.</param>
  public void Write(string header, string payload)
  {
    AnsiConsole.Write(
      new Panel(new JsonText(header))
        .Header("Header")
        .Collapse()
        .RoundedBorder()
    );
    AnsiConsole.Write(
      new Panel(new JsonText(payload))
        .Header("Payload")
        .Collapse()
        .RoundedBorder()
    );
  }
}
