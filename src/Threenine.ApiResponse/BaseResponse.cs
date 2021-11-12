using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Threenine.ApiResponse
{
    public abstract  class BaseResponse
    {
        private readonly IList<string> _errorMessages;
        
        protected BaseResponse(IList<string> errors = null)
        {
            _errorMessages = errors ?? new List<string>();
        }

        public bool IsValid => !_errorMessages.Any();

        public IList<string> Errors => _errorMessages;
    }
}