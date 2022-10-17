namespace BookShelter.WebAPI.Commons.Utils;

public class PaginationMetaData
{
    public uint PageSize { get; private set; }

    public uint CurrentPage { get; private set; }

    public uint TotalPages { get; private set; }

    public bool HasPrevious { get; private set; }

    public bool HasNext { get; private set; }

    public PaginationMetaData(int totalCount, int pageIndex, int pageSize)
    {
        CurrentPage = (uint)pageIndex;
        PageSize = (uint)pageSize;
        TotalPages = (uint)Math.Ceiling((double)totalCount / pageSize);
        HasPrevious = pageIndex > 1;
        HasNext = pageIndex < TotalPages;
    }
}
