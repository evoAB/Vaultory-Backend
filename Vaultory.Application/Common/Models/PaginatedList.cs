using Microsoft.EntityFrameworkCore;

namespace Vaultory.Application.Common.Models;

public class PaginatedList<T>
{
    public List<T> Items { get; private set; } = new();
    public int PageNumber { get; private set; }
    public int TotalPages { get; private set; }
    public int PageSize { get; private set; }
    public int TotalCount { get; private set; }
    public bool HasPreviousPage => PageNumber > 1;
    public bool HasNextPage => PageNumber < TotalPages;

    private PaginatedList(List<T> items, int count, int pageNumber, int pageSize)
    {
        Items = items;
        TotalCount = count;
        PageNumber = pageNumber;
        PageSize = pageSize;
        TotalPages = (int)Math.Ceiling(count / (double)pageSize);
    }

    public static async Task<PaginatedList<T>> CreateAsync(IQueryable<T> source, int pageNumber, int pageSize, CancellationToken cancellationToken = default)
    {
        var count = await source.CountAsync(cancellationToken);
        var items = await source.Skip((pageNumber - 1) * pageSize)
                                .Take(pageSize)
                                .ToListAsync(cancellationToken);

        return new PaginatedList<T>(items, count, pageNumber, pageSize);
    }
}