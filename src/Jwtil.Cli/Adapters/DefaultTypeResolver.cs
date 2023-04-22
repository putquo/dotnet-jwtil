using Spectre.Console.Cli;

namespace Jwtil.Cli.Adapters;

internal class DefaultTypeResolver : ITypeResolver, IDisposable
{
    private readonly IServiceProvider _provider;

    public DefaultTypeResolver(IServiceProvider provider)
    {
      _provider = provider ?? throw new ArgumentNullException(nameof(provider));
    }

    public object? Resolve(Type? type)
    {
      if (type is null)
      {
        throw new ArgumentNullException(nameof(type));
      }

      return _provider.GetService(type);
    }

    public void Dispose()
    {
      if (_provider is IDisposable disposable)
      {
        disposable.Dispose();
      }
    }
}
