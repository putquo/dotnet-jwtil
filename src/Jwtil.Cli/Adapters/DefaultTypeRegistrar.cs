using Jwtil.Cli.Adapters;
using Microsoft.Extensions.DependencyInjection;
using Spectre.Console.Cli;

namespace Jwtil.Cli.Registrars;

internal class DefaultTypeRegistrar : ITypeRegistrar
{
  private readonly IServiceCollection _services;

  public DefaultTypeRegistrar(IServiceCollection services)
  {
    _services = services;
  }

  public ITypeResolver Build()
  {
    return new DefaultTypeResolver(_services.BuildServiceProvider());
  }

  public void Register(Type service, Type implementation)
  {
    _services.AddSingleton(service, implementation);
  }

  public void RegisterInstance(Type service, object implementation)
  {
    _services.AddSingleton(service, implementation);
  }

  public void RegisterLazy(Type service, Func<object> factory)
  {
    if (factory is null)
    {
      throw new ArgumentNullException(nameof(factory));
    }
    _services.AddSingleton(service, (provider) => factory());
  }
}
