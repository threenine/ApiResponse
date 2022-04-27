using System.Collections.Generic;

namespace Threenine.ApiResponse
{
    public class ListResponse<TModel> : BaseResponse, IListResponse<TModel> where TModel : class
    {
        public ListResponse(List<TModel> model,  IList<KeyValuePair<string, string[]>> validationErrors = null) : base(validationErrors)
        {
            Items = model;
        }

        public int From { get; set; }
        public int Size { get; set; }
        public int Page { get; set; }
        public int PerPage { get; set; }
        public int TotalPages { get; set; }
        public List<TModel> Items { get; }
        public bool  HasPrevious { get; set; }
        public bool HasNext { get; set; }
        
    }
}