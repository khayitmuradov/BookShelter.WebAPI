using BookShelter.WebAPI.Commons.Utils;

namespace BookShelter.WebAPI.Commons.Extensions;

public static class PaginationExtensions
{
    public static IEnumerable<T> ToPagedList<T>(this IQueryable<T> source, PaginationParams @params)
    {
        if (@params is null) @params = new PaginationParams(1, 25);

        var metadata = new PaginationMetaData(source.Count(), @params.PageIndex, @params.PageSize);



        return new List<T>();
    }
}
