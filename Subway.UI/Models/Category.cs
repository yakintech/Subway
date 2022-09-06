using System.Text.Json.Serialization;

namespace Subway.UI.Models
{
    public class Category
    {
        [JsonPropertyName("title")]
        public string? Name { get; set; }

        public string? Description { get; set; }
    }
}
