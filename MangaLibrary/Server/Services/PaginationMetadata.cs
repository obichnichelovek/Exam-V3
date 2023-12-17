namespace MangaLibrary.Shared.Services;

public sealed class PaginationMetadata
{
    public int ItemCount { get; set; }
    public int PageCount { get; set; }
    public int PageSize { get; set; }
    public int Page { get; set; }

    public PaginationMetadata(int itemCount, int pageSize, int page)
    {
        ItemCount = itemCount;
        PageSize = pageSize;
        Page = page;

        PageCount = (int)Math.Ceiling(itemCount / (double)PageSize);
    }
}
