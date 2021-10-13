using System.Collections.Generic;

namespace Threenine.ApiResponse
{
    public class Response<TModel> : BaseResponse where TModel : class
    {
        public Response(TModel model, IList<string> validationErrors = null) : base(validationErrors)
        {
            Item = model;
        }
        
        public TModel Item { get; }

        public IList<Link> Links { get; set; }
    }
}