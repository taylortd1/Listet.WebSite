using System.Text.Json;
using System.Text.Json.Serialization;

namespace Listet.WebSite.Models;

public class Product
{
    public string? Id { get; set; }
    public string? Maker { get; set; }
        
    //maps the img property in the json to the Image property in the class
    [JsonPropertyName("img")]
    public string? Image { get; set; }
    public string? Url { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public int[]? Ratings { get; set; }
        
    public override string ToString() => JsonSerializer.Serialize<Product>(this);
    
    

}
