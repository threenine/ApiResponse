using System.Collections;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Threenine.ApiResponse
{
    public class ListResponse<TModel> : BaseResponse  where TModel : class
    {
        public ListResponse(IList<TModel> model, IList<string> validationErrors = null) : base(validationErrors)
        {
            Items = model;
        }

        public int Page { get; set; }
        public int PerPage { get; set; }
        public int TotalPages { get; set; }
        public IList<TModel> Items { get; }
    }
}