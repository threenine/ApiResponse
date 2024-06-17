using System.Collections.Generic;

namespace Threenine
{
    /// <summary>
    /// Marker interface to define list response
    /// </summary>
    public interface IListResponse{}
    
    /// <summary>
    /// Define a list response with a payload
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    public interface IListResponse<TModel> : IListResponse where TModel : class
    {
        List<TModel> Items { get; } 
    }
}