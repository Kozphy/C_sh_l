using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MiddlewareExample.CustomMiddleware;
using MvcMovie.CustomMiddleware;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<MyCustomMiddleware>();

// need refactor
Dictionary<string, string?> connectStringsCollection = new Dictionary<string, string?>();
connectStringsCollection.Add("laptopMvcMovieContext", builder.Configuration.GetConnectionString("laptopMvcMovieContext"));
connectStringsCollection.Add("laptopProductionMvcMovieContext", builder.Configuration.GetConnectionString("laptopMvcMovieContext"));

var computerType = builder.Configuration.GetSection("laptop");
if(Convert.ToBoolean(computerType["mobile_tablet"])){
    if (builder.Environment.IsDevelopment())
    {
        // In dev using SQLite
        builder.Services.AddDbContext<MvcMovieContext>(options =>
            options.UseSqlite(connectStringsCollection["laptopMvcMovieContext"]!));
    }
    else
    {
        // In production using SQLServer
        builder.Services.AddDbContext<MvcMovieContext>(options =>
            options.UseSqlServer(connectStringsCollection["laptopProductionMvcMovieContext"]!));
    }
}else {
    if (builder.Environment.IsDevelopment())
    {
        // In dev using SQLite
        builder.Services.AddDbContext<MvcMovieContext>(options =>
            options.UseSqlite(connectStringsCollection["desktopMvcMovieContext"]!));
    }
    else
    {
        // In production using SQLServer
        builder.Services.AddDbContext<MvcMovieContext>(options =>
            options.UseSqlServer(connectStringsCollection["desktopProductionMvcMovieContext"]!));
    }

}


// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// app.UseEndpoints(endpoints =>
// {
//     endpoints.Map("files/{filename}.{extension}", async context =>
//     {
//         string? fileName = Convert.ToString(context.Request.RouteValues["filename"]);
//         string? extension = Convert.ToString(context.Request.RouteValues["extension"]);
//         await context.Response.WriteAsync($"In files -{fileName} - {extension}");
//     });

//     endpoints.Map("employee/profile/{EmployName=harsha}", async context => {
//         string? employName = Convert.ToString(context.Request.RouteValues["employname"]);
//         await context.Response.WriteAsync($"In Employee profile - {employName}");
//     });

//     endpoints.Map("products/details/{id:int?}", async context =>
//     {
//         if (context.Request.RouteValues.ContainsKey("id"))
//         {
//             string? id = Convert.ToString(context.Request.RouteValues["id"]);
//             await context.Response.WriteAsync($"Products details - {id}");
//         }
//         else {
//             await context.Response.WriteAsync($"Products details - id is not supplied");
//         }
//     });
// });

// app.UseEndpoints(endpoints =>
// {
//     // add your endpoints here

//     endpoints.MapGet("map1", async (context) =>
//     {
//         await context.Response.WriteAsync("In Map 1");
//     });

//     endpoints.MapPost("map2", async (context) =>
//     {
//         await context.Response.WriteAsync("In Map 2");
//     });
// });



app.UseAuthorization();

app.MapControllerRoute(
   name: "default",
   pattern: "{controller=Home}/{action=Index}/{id?}");


// middleware 1
//app.Use(async (HttpContext context, RequestDelegate next) =>
//{
//    await context.Response.WriteAsync("Hello");
//    await next(context);
//});

// middleware UseWhen
//app.UseWhen(
//    context => context.Request.Query.ContainsKey("username"),
//    app =>
//    {
//        app.Use(async (context, next) =>
//        {
//            await context.Response.WriteAsync("Hello from Middleware branch");
//            await next();
//        });
//    }
//);

//app.Use(async (HttpContext context, RequestDelegate next) =>
//    await context.Response.WriteAsync("Hello from main middleware.")
//); 

// middleware 2
//app.UseMiddleware<MyCustomMiddleware>();
//app.UseMyCustomMiddleware();

// conventional middleware
//app.UseConventional_middleware();

// middleware 3
app.Use(async (HttpContext context, RequestDelegate next) =>
{
   await context.Response.WriteAsync(Directory.GetCurrentDirectory() + "\r\n");
   await next(context);
});

// IConfiguration configuration = new ConfigurationBuilder()
//     .SetBasePath(Directory.GetCurrentDirectory())
//     .AddJsonFile("appsettings.json")
//     .Build();

// var env = configuration.GetValue<string>("ConnectionStrings");

app.Use(async (HttpContext context, RequestDelegate next) =>
{
    var env = builder.Configuration.GetSection("laptop");
    if(Convert.ToBoolean(env["mobile_tablet"])){

        await context.Response.WriteAsync(env["mobile_tablet"]!);
        await context.Response.WriteAsync("laptop env");
    }else
    {
        await context.Response.WriteAsync(env["mobile_tablet"]!);
        await context.Response.WriteAsync("not laptop env");
    }
});


// app.Run(async context =>
// {
//     await context.Response.WriteAsync($"Request received at {context.Request.Path}");
// }
// );


app.Run();
