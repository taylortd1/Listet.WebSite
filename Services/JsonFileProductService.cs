using Listet.WebSite.Models;
using System.Text.Json;

namespace Listet.WebSite.Services;

//Add a web api for products
public class JsonFileProductService
{
    public JsonFileProductService(IWebHostEnvironment webHostEnvironment)
    {
        WebHostEnvironment = webHostEnvironment;
    }

    public IWebHostEnvironment WebHostEnvironment { get; set; }

    //many web paths are case sensitive, so we need to make sure we get the case right
    private string JsonFileName => Path.Combine(WebHostEnvironment.WebRootPath, "Data", "products.json");

    //this method retrieves the products from the json file
    public IEnumerable<Product> GetProducts()
    {

        Console.WriteLine(JsonFileName);
        using var jsonFileReader = File.OpenText(JsonFileName);
        return JsonSerializer.Deserialize<Product[]>(jsonFileReader.ReadToEnd(),
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            })!;
        
    }
}
