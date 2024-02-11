using Microsoft.CodeAnalysis;
using System.Linq;

namespace SourceGeneratorsToolkit.Providers;

public static class ProviderExtensions
{
    public static IncrementalValuesProvider<TSource> Concat<TSource>(this IncrementalValuesProvider<TSource> source, IncrementalValuesProvider<TSource> other)
    {
        return source.Collect().Combine(other.Collect()).SelectMany((x, y) => x.Left.Concat(x.Right));
    }

}
