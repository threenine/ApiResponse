namespace Threenine.ApiResponse
{
    public interface ISingleResponse<TModel> where TModel : class
    {
        TModel Item { get; }
    }
}