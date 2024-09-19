using System.Collections.Generic;

namespace Threenine
{
    /// <summary>
    /// Marker interface to define list response
    /// </summary>
    public interface IPaginatedResponse
    {
        int Size { get; set; }
        int Page { get; set; }
        int PerPage { get; set; }
        int Total { get; set; }
        bool HasPrevious { get; set; }
        bool HasNext { get; set; }
    }

    /// <summary>
    /// Define a list response with a payload
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    public interface IPaginatedResponse<TModel> : IPaginatedResponse where TModel : class
    {
        IReadOnlyList<TModel> Items { get; }
       
    }
}