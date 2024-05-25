namespace Lab.Core.Commons.Communication;

public static class PagedResultExtensions
{
    public static PagedResult<TOutput> MapItems<TInput, TOutput>(this PagedResult<TInput> pagedResult,
        Func<TInput, TOutput> converter) where TInput : class where TOutput : class
    {
        var convertedItems = pagedResult.Items.Select(converter);

        return new PagedResult<TOutput>(
            convertedItems,
            pagedResult.TotalItems,
            pagedResult.PageIndex,
            pagedResult.PageSize,
            pagedResult.Filter
        );
    }
}