namespace Threenine
{
    /// <summary>
    /// Marker interface to define a Single Response
    /// </summary>
    public interface IResponse{}
    
    /// <summary>
    /// Define a single response with a payload
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    public interface IResponse<out TModel> : IResponse where TModel : class
    {
        TModel Item { get; }
    }
}