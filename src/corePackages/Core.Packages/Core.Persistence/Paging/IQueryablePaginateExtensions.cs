using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Core.Persistence.Paging;

public static class IQueryablePaginateExtensions
{
    public static async Task<T> ToPaginateAsync<T>(
        this IQueryable<T> source,
        int index,
        int size,
        CancellationToken cancellationToken = default) 
    {
        int count = await source.CountAsync(cancellationToken).ConfigureAwait(false); 

        List<T> items = await source.Skip(index * size)
            .Take(size)
            .ToListAsync(cancellationToken)
            .ConfigureAwait(false);

        Paginate<T> list = new Paginate<T>()
        {
            Index = index,
            Size = size,
            Count = count,
            Items = items,
            Pages = (int)Math.Ceiling(count / (double)size)
        };

        return list; 
    };
}
