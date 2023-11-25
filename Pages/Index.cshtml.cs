using System.Collections.Generic;
using Listet.WebSite.Models;
using Listet.WebSite.Services;
using Listet.WebSite.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Listet.WebSite.Components;


namespace Listet.WebSite.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger _logger;

    public JsonFileProductService _productService;

    //dereference the products 
    public IEnumerable<Product>? Products { get; private set; }

    public IndexModel(ILogger<IndexModel> logger,
                      JsonFileProductService productService)
    {

        _logger = logger;
        _productService = productService;
    }
    
    

    public void OnGet() => Products = _productService.GetProducts();
}