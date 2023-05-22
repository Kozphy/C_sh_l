using ControllersExample.Controllers;

namespace ControllersExample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();
            //builder.Services.AddTransient<HomeController>();

            var app = builder.Build();

            app.UseRouting();
            app.MapControllers();
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();
            //});

            //app.MapGet("/", () => "Hello World!");

            app.Run();
        }
    }
}