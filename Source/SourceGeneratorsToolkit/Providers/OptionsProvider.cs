using Microsoft.CodeAnalysis.Diagnostics;
using System;

namespace SourceGeneratorsToolkit.Providers;


public class OptionsProvider
{
    private readonly AnalyzerConfigOptionsProvider _provider;
    private readonly string? _prefix;

    internal OptionsProvider(AnalyzerConfigOptionsProvider provider, string prefix)
    {
        _provider = provider;
        _prefix = prefix;
    }

    public T GetOption<T>(string key, T defaultValue)
    {
        if (_provider.GlobalOptions.TryGetValue(_prefix + key, out var value))
        {
            try
            {
                return (T)Convert.ChangeType(value, typeof(T));
            }
            catch (Exception ex) when (ex is FormatException || ex is InvalidCastException)
            {
                return defaultValue;
            }
        }
        return defaultValue;
    }
}


public static class OptionsProviderExtensions
{
    public static OptionsProvider ToProvider(this AnalyzerConfigOptionsProvider provider, string prefix = "")
    {
        return new OptionsProvider(provider, prefix);
    }
}
