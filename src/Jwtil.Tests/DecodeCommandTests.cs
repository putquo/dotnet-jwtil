using System.IdentityModel.Tokens.Jwt;
using Jwtil.Cli.Commands;
using Jwtil.Cli.Registrars;
using Jwtil.Core.Services;
using Jwtil.Core.Writers;
using Microsoft.Extensions.DependencyInjection;
using Spectre.Console;
using Spectre.Console.Cli;
using Spectre.Console.Testing;
using Xunit.Abstractions;

namespace Jwtil.Tests;

public sealed class DecodeCommandTests
{
    public sealed class TheDecodeCommand
    {
        private readonly IServiceCollection _serviceCollection;

        public TheDecodeCommand()
        {
            _serviceCollection = new ServiceCollection();
            _serviceCollection.AddSingleton<IJwtDecoder, DefaultJwtDecoder>();
            _serviceCollection.AddSingleton<IJwtWriter, DefaultJwtWriter>();
            _serviceCollection.AddSingleton(_ => new JwtSecurityTokenHandler());
        }

        [Theory]
        [InlineData("abc")]
        [InlineData("a.b.c")]
        [InlineData("123")]
        [InlineData("1.2.3")]
        [InlineData("eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ")]
        public async Task Should_Output_Error_When_The_Token_Is_Invalid(string args)
        {
            var app = GetCommandApp();
            AnsiConsole.Record();

            var result = await app.RunAsync(new[] { args });
            var output = AnsiConsole.ExportText();

            Assert.Equal(1, result);
            Assert.Contains("Error: The <token> argument is an invalid JSON Web Token.", output);
        }

        [Theory]
        [InlineData("eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c")]
        public async Task Should_Output_Unverified_Header_And_Payload(string args)
        {
            var app = GetCommandApp();
            AnsiConsole.Record();

            var result = await app.RunAsync(new[] { args });
            var output = AnsiConsole.ExportText();

            Assert.Equal(0, result);
            Assert.Contains("""
╭─Header 👎──────────╮
│ {                  │
│    "alg": "HS256", │
│    "typ": "JWT"    │
│ }                  │
╰────────────────────╯
╭─Payload 👎──────────────╮
│ {                       │
│    "sub": "1234567890", │
│    "name": "John Doe",  │
│    "iat": 1516239022    │
│ }                       │
╰─────────────────────────╯
""", output);
        }

        private CommandApp GetCommandApp()
        {
            var app = new CommandApp(new DefaultTypeRegistrar(_serviceCollection));
            app.Configure(config =>
            {
            config.AddCommand<DecodeCommand>("decode")
                .WithDescription("Decode a JSON Web Token")
                .WithExample(new[] { "decode", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c" });
            });
            app.SetDefaultCommand<DecodeCommand>();
            return app;
        }
    }

}