using System.Collections.Generic;

namespace Threenine.ApiResponse
{
    public interface IListResponse<TModel> where TModel : class
    {
        IList<TModel> Items { get; } 
    }
}