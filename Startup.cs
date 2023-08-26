using Listet.WebSite.Models;
using Listet.WebSite.Services;
using Microsoft.Extensions.FileProviders;
using System.Text.Json;

namespace Listet.WebSite;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    // This method is called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        //this is where we add the json file product service
        services.AddRazorPages();
        services.AddTransient<JsonFileProductService>();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    // This method is called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder? app, IWebHostEnvironment env)
    {
        //this is where we add the json file product service
        if (app == null)
        {
            throw new ArgumentNullException(nameof(app));
        }

        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Error");
            //Default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapRazorPages();
            endpoints.MapGet("/products", (context) =>
            {
                //gets the json file product service
                var products = app.ApplicationServices.GetService<JsonFileProductService>().GetProducts();
                
                //creates a json string from the products
                var json = JsonSerializer.Serialize(products);
                
                //writes the json string to the response
                return context.Response.WriteAsync(json);
            });
        });
    }       
}
