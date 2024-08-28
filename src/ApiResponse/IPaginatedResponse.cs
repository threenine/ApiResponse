using System.Collections.Generic;

namespace Threenine
{
    /// <summary>
    /// Marker interface to define list response
    /// </summary>
    public interface IPaginatedResponse{}
    
    /// <summary>
    /// Define a list response with a payload
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    public interface IPaginatedResponse<TModel> : IPaginatedResponse where TModel : class
    {
        List<TModel> Items { get; } 
    }
}