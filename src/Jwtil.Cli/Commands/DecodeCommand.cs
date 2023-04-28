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
public class DecodeCommand : AsyncCommand<DecodeCommand.Settings>
{
  /// <summary>
  ///     Class <c>DecodeCommand.Settings</c> describes the settings for <c>DecodeCommand</c>.
  /// </summary>
  public class Settings : CommandSettings
  {
    [CommandArgument(0, "<token>")]
    [Description("The JSON Web Token")]
    public string Token { get; set; } = default!;
  }

  private readonly IJwtDecoder _decoder;
  private readonly IJwtWriter _writer;

  public DecodeCommand(IJwtDecoder decoder, IJwtWriter writer)
  {
    _decoder = decoder;
    _writer = writer;
  }

  public override async Task<int> ExecuteAsync([NotNull] CommandContext context, [NotNull] Settings settings)
  {
    try
    {
      var decodedToken = await _decoder.DecodeAsync(settings.Token);
      _writer.Write(decodedToken);
      return 0;
    }
    catch (Exception ex)
    {
      AnsiConsole.MarkupLineInterpolated($"[bold red]Error:[/] {ex.Message}");
      return 1;
    }
  }
}
