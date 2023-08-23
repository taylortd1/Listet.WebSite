using Listet.WebSite.Models;
using System.Text.Json;

namespace Listet.WebSite.Services;

public class JsonFileProductService
{
    public JsonFileProductService(IWebHostEnvironment webHostEnvironment)
    {
        WebHostEnvironment = webHostEnvironment;
    }

    public IWebHostEnvironment WebHostEnvironment { get; }

    //many web paths are case sensitive, so we need to make sure we get the case right
    private string JsonFileName => Path.Combine(WebHostEnvironment.WebRootPath, "data", "products.json");

    //this method retrieves the products from the json file
    public IEnumerable<Product> GetProducts()
    {
        using (var jsonFileReader = File.OpenText(JsonFileName))
        {
            return JsonSerializer.Deserialize<Product[]>(jsonFileReader.ReadToEnd(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                })!;
        }
    }
}
