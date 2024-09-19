using System.Collections.Generic;

namespace Threenine
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class BaseResponse(List<KeyValuePair<string, string[]>> errors = null)
    {
        public bool IsValid => Errors.Count == 0;

        public List<KeyValuePair<string, string[]>> Errors { get; } = errors ?? [];
    }
}