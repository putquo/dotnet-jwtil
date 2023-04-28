using Jwtil.Cli.Commands;
using Jwtil.Cli.Registrars;
using Jwtil.Core.Services;
using Jwtil.Core.Writers;
using Microsoft.Extensions.DependencyInjection;
using Spectre.Console.Cli;
using System.IdentityModel.Tokens.Jwt;

var serviceCollection = new ServiceCollection();
serviceCollection.AddSingleton<IJwtDecoder, DefaultJwtDecoder>();
serviceCollection.AddSingleton<IJwtWriter, DefaultJwtWriter>();
serviceCollection.AddSingleton(_ => new JwtSecurityTokenHandler());
var registrar = new DefaultTypeRegistrar(serviceCollection);

var app = new CommandApp(registrar);
app.Configure(config =>
{
  config.AddCommand<DecodeCommand>("decode")
    .WithDescription("Decode a JSON Web Token")
    .WithExample(new[] { "decode", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c" });
});
app.SetDefaultCommand<DecodeCommand>();

await app.RunAsync(args);

