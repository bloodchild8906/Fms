using System;
using System.Linq;
using System.Linq.Expressions;

namespace Fms.Application.Core.Extensions;

public static class FilterExtension
{
    // ReSharper disable once FlagArgument
    public static IQueryable<TSource> WhereIf<TSource>(this IQueryable<TSource> source, bool condition, Expression<Func<TSource, bool>> predicate)
    {
        if (condition)
            return source.Where(predicate);

        return source;
    }
}