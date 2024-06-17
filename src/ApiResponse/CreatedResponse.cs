using System.Collections.Generic;

namespace Threenine;

/// <summary>
/// Provides response template for single entity
/// </summary>
/// <typeparam name="TModel"></typeparam>
public class CreatedResponse<TModel> : BaseResponse, ICreatedResponse<TModel> where TModel : class 
{
    public CreatedResponse(TModel model,  List<KeyValuePair<string, string[]>> validationErrors = null) : base(validationErrors)
    {
        Item = model;
    }
    
    public string Id { get; set; }
    public TModel Item { get; }
   
}
