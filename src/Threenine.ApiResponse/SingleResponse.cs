using System.Collections.Generic;

namespace Threenine.ApiResponse
{
    public class SingleResponse<TModel> : BaseResponse, ISingleResponse<TModel> where TModel : class 
    {
        public SingleResponse( IList<string> validationErrors = null) : base(validationErrors)
        {
        }
        public TModel Item => null;
    }
}