using System.Text.Json.Serialization;

namespace B3Test.Application.DTOs
{
    public abstract class AResponse
    {
        [JsonIgnore]
        public IEnumerable<string>? Errors { get; set; }
        public bool HasErrors => Errors != null;
    }
}
