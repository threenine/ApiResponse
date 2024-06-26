using System.Collections.Generic;

namespace Threenine
{
    /// <summary>
    /// Provides support for pagination of list objects
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    public class ListResponse<TModel> : BaseResponse, IListResponse<TModel> where TModel : class
    {
        public ListResponse(List<TModel> model,  List<KeyValuePair<string, string[]>> validationErrors = null) : base(validationErrors)
        {
            Items = model;
        }
        
        public int Size { get; set; }
        public int Page { get; set; }
        public int PerPage { get; set; }
        public int TotalPages { get; set; }
        public List<TModel> Items { get; }
        public bool  HasPrevious { get; set; }
        public bool HasNext { get; set; }
    }
}