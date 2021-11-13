using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Threenine.ApiResponse
{
    public abstract  class BaseResponse
    {
        private readonly IList<KeyValuePair<string, string[]>> _errorMessages;
        
        protected BaseResponse( IList<KeyValuePair<string, string[]>> errors = null)
        {
            _errorMessages = errors ?? new List<KeyValuePair<string, string[]>>();
        }

        public bool IsValid => !_errorMessages.Any();

        public IList<KeyValuePair<string, string[]>> Errors => _errorMessages;
    }
}