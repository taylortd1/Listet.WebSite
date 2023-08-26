using System.Text.Json;
using System.Text.Json.Serialization;

namespace Listet.WebSite.Models;


public class Product
{
    public required string Id { get; set; }
    public required string Maker { get; set; }
        
    //maps the img property in the json to the Image property in the class
    [JsonPropertyName("img")]
    public required string Image { get; set; }
    public required string Url { get; set; }
    public required string Title { get; set; }
    //public required int[] Ratings { get; set; }
    public required string Description { get; set; }
        
    public override string ToString() => JsonSerializer.Serialize(this);
}
