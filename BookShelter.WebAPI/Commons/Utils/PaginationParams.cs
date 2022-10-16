namespace BookShelter.WebAPI.Commons.Utils;

public class PaginationParams
{
    public int PageIndex { get; set; }

    public int PageSize { get; set; }

    public int GetSkipCount() => (PageIndex - 1) * PageSize;

    public PaginationParams()
    {

    }

    public PaginationParams(int pageIndex, int pageSize)
    {
        PageIndex = pageIndex;
        PageSize = pageSize;
    }
}
