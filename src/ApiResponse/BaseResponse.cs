using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Threenine.ApiResponse
{
    /// <summary>
    /// 
    /// </summary>
    public abstract  class BaseResponse
    {
        protected BaseResponse( List<KeyValuePair<string, string[]>> errors = null)
        {
            Errors = errors ?? new List<KeyValuePair<string, string[]>>();
        }

        public bool IsValid => !Errors.Any();

        public List<KeyValuePair<string, string[]>> Errors { get; }
    }
}