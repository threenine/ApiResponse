using System;

namespace Threenine.ApiResponse;

/// <summary>
/// Actions are used to describe the actions that can be performed on a resource.
/// 
/// </summary>
public class Actions
{
    public string Name { get; set; }
    public Uri Url { get; set; }
    public string Method { get; set; }
    public string Summary { get; set; }
}