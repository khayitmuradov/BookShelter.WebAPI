using BookShelter.WebAPI.Commons.Exceptions;

namespace BookShelter.WebAPI.Commons.Utils;

public class PaginationParams
{
    private const int maxPageSize = 50;

    public int PageIndex { get; set; }

    private int pageSize;

    public int PageSize
    {
        get { return pageSize; }
        set
        {
            if (value < maxPageSize)
                pageSize = value;
            else
                throw new StatusCodeException(System.Net.HttpStatusCode.BadRequest,
                    $"Page size must be less than {maxPageSize}");
        }
    }

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
