using System.Collections.Generic;
using Listet.WebSite.Models;
using Listet.WebSite.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
//Add a web api for products
namespace Listet.WebSite.Controllers;


[ApiController]
[Route("[controller]")]
public class ProductsController : ControllerBase
{
    //this is where we add the json file product service
    public ProductsController(JsonFileProductService productService)
    {
        ProductService = productService;
    }

    //dereference the products
    public JsonFileProductService ProductService { get; }

    //this method retrieves the products from the json file

    [HttpGet]
    public IEnumerable<Product> Get() => ProductService.GetProducts();

    [HttpPatch]
    public ActionResult Patch([FromBody] RatingRequest request)
    {
        if (request?.ProductId == null)
            return BadRequest();

        ProductService.AddRating(request.ProductId, request.Rating);

        return Ok();
    }

    public class RatingRequest
    {
        public string? ProductId { get; set; }
        public int Rating { get; set; }

    }
}

