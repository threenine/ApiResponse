using System;
using System.Collections.Generic;
using System.Linq;

namespace Threenine
{
    /// <summary>
    /// Provides support for pagination of list objects
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    public class PaginatedResponse<TModel>(
        IReadOnlyList<TModel> model,
        List<KeyValuePair<string, string[]>> validationErrors = null)
        : BaseResponse(validationErrors), IPaginatedResponse<TModel>
        where TModel : class
    {
        public int Size { get; set; }
        public int Page { get; set; }
        public int PerPage { get; set; }
        public int Total { get; set; }
        public IReadOnlyList<TModel> Items { get; } = model;
        public bool HasPrevious { get; set; } = false;
        public bool HasNext { get; set; } = false;
       
        public IReadOnlyList<TModel> Match<T>(Func<IReadOnlyList<TModel>, IReadOnlyList<TModel>> onSuccess, Func< List<KeyValuePair<string, string[]>>, IReadOnlyList<TModel>> onFailure)
        {
            return IsValid ? onSuccess(Items) : onFailure(Errors);
        }
    }
}