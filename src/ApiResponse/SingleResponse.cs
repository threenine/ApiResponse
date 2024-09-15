using System.Collections.Generic;


namespace Threenine
{
    /// <summary>
    /// Provides response template for single entity
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    public class SingleResponse<TModel> : BaseResponse, ISingleResponse<TModel> where TModel : class 
    {
        public SingleResponse(TModel model,  List<KeyValuePair<string, string[]>> validationErrors = null) : base(validationErrors)
        {
            Item = model;
        }
        public TModel Item { get; }
       
    }
}