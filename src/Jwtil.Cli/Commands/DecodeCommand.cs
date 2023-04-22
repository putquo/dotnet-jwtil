using Jwtil.Core.Services;
using Jwtil.Core.Writers;
using Spectre.Console;
using Spectre.Console.Cli;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace Jwtil.Cli.Commands;

/// <summary>
///     Class <c>DecodeCommand</c> describes a CLI command for decoding a JSON Web Token.
/// </summary>
public class DecodeCommand : Command<DecodeCommand.Settings>
{
  /// <summary>
  ///     Class <c>DecodeCommand.Settings</c> describes the settings for <c>DecodeCommand</c>.
  /// </summary>
  public class Settings : CommandSettings
  {
    [CommandArgument(0, "<token>")]
    [Description("The JSON Web Token")]
    public string Jwt { get; set; } = default!;
  }

  private readonly IJwtDecoder _decoder;
  private readonly IJwtWriter _writer;

  public DecodeCommand(IJwtDecoder decoder, IJwtWriter writer)
  {
    _decoder = decoder;
    _writer = writer;
  }

  public override int Execute([NotNull] CommandContext context, [NotNull] Settings settings)
  {
    var (header, payload) = _decoder.Decode(settings.Jwt);
    _writer.Write(header, payload);
    return 0;
  }
}
