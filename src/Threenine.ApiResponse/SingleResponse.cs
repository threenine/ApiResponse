using System.Collections.Generic;

namespace Threenine.ApiResponse
{
    public class SingleResponse<TModel> : BaseResponse, ISingleResponse<TModel> where TModel : class 
    {
        public SingleResponse(TModel model,  IList<KeyValuePair<string, string[]>> validationErrors = null) : base(validationErrors)
        {
            Item = model;
        }
        public TModel Item { get; }
    }
}