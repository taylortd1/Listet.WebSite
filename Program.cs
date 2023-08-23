namespace Listet.WebSite;

public class Program
{
    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    // This method gets called by the runtime. Use this method to add services to the container.
    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(webBuilder =>
        {
            //adds startup configurations to the container.
            webBuilder.UseStartup<Startup>();
        });


}
