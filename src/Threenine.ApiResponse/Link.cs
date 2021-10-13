using System.Text.Json.Serialization;

namespace Threenine.ApiResponse
{
    public class Link
    {
        public string Href { get; set; }
        public string Rel { get; set; }
        public string Method { get; set; }
    }
}