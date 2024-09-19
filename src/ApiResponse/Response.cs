using System;
using System.Collections.Generic;
namespace Threenine;

/// <summary>
/// Provides response template for single entity
/// </summary>
/// <typeparam name="TModel"></typeparam>
public class Response<TModel>(TModel model, List<KeyValuePair<string, string[]>> validationErrors = null)
    : BaseResponse(validationErrors), IResponse<TModel>
    where TModel : class
{
    public TModel Item { get; } = model;
        
    public TModel Match<T>(Func<TModel, TModel> onSuccess, Func< List<KeyValuePair<string, string[]>>, TModel> onFailure)
    {
        return IsValid ? onSuccess(Item) : onFailure(Errors);
    }
}