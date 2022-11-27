namespace Threenine.ApiResponse;

public interface ICreatedResponse
{
    public string Id { get; set; }
}

public interface ICreatedResponse<out TModel> : ICreatedResponse where TModel : class
{
    TModel Item { get; }
}