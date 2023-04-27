using System;
using System.Collections.Generic;

namespace Fms.Application.Core.Common.Responses;

public record PaginatedList<T>
{
    public int CurrentPage { get; init; }
    public int TotalPages { get; init; }
    public int TotalItems { get; init; }

    // ReSharper disable once CollectionNeverQueried.Global
    public List<T> Result { get; init; } = new List<T>();

    public PaginatedList(List<T> items, int count, int currentPage, int pageSize)
    {
        CurrentPage = currentPage;
        TotalPages = (int)Math.Ceiling(count / (double)pageSize);
        TotalItems = count;
        Result.AddRange(items);
    }

    public PaginatedList()
    {

    }
}