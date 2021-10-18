using System.Collections.Generic;

namespace Threenine.ApiResponse
{
    public class Response<TModel> : BaseResponse, ISingleResponse<TModel> where TModel : class 
    {
        public Response(TModel model, IList<string> validationErrors = null) : base(validationErrors)
        {
            Item = model;
        }
        
      

        public IList<Link> Links { get; set; }
        public TModel Item { get; }
    }
}