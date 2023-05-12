using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MiddlewareExample.CustomMiddleware;
using MvcMovie.CustomMiddleware;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using System.Drawing.Text;
using Serilog;
using Azure.Identity;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using MvcMovie.logger;

//using System.Environment.NewLine;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<MyCustomMiddleware>();

// Logging

// Serilog
StackTrace st = new StackTrace(true);
using var log = new LoggerConfiguration()
    .WriteTo.Console(outputTemplate:
        "[{Timestamp:HH:mm:ss} {fileName}:{lineNum} {Level:u3}] {Message:lj}   {NewLine}{Exception} ")
    .CreateLogger();

Log.Logger = log;


//builder.Host.UseSerilog((HttpBuilderContext context, IServiceProvider services, LoggerConfiguration loggerConfiguration) => { 
//})


// need refactor
Dictionary<string, string?> connectStringsCollection = new Dictionary<string, string?>();
connectStringsCollection.Add("laptopMvcMovieContext", builder.Configuration.GetConnectionString("MSSQL"));
connectStringsCollection.Add("laptopProductionMvcMovieContext", builder.Configuration.GetConnectionString("MSSQL"));
connectStringsCollection.Add("desktopMvcMovieContext", builder.Configuration.GetConnectionString("MSSQL"));
connectStringsCollection.Add("desktopProductionMvcMovieContext", builder.Configuration.GetConnectionString("MSSQL"));


var computerType = builder.Configuration.GetSection("laptop");
//var logger = new Logger();
if (Convert.ToBoolean(computerType["mobile_tablet"]))
{
    if (builder.Environment.IsDevelopment())
    {
        builder.Services.AddDbContext<MvcMovieContext>(options =>
            options.UseSqlServer(connectStringsCollection["laptopMvcMovieContext"]!));
        
        // TODO:
        log.Here().Information(connectStringsCollection["laptopMvcMovieContext"]);

        //Logger.LogInfomation(connectStringsCollection["laptopMvcMoviceContext"])
    }
    else
    {
        // In production using SQLServer
        builder.Services.AddDbContext<MvcMovieContext>(options =>
            options.UseSqlServer(connectStringsCollection["laptopProductionMvcMovieContext"]!));
    }
}
else
{
    if (builder.Environment.IsDevelopment())
    {
        // In dev using SQLite
        builder.Services.AddDbContext<MvcMovieContext>(options =>
            options.UseSqlServer(connectStringsCollection["desktopMvcMovieContext"]!));
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


//app.Use(async (HttpContext context, RequestDelegate next) => { 
    //await context.Response.WriteAsync("Hello from main middleware.");
//    await next(context);
//});

// middleware 2
//app.UseMiddleware<MyCustomMiddleware>();
//app.UseMyCustomMiddleware();

// conventional middleware
//app.UseConventional_middleware();
//app.UseGetParametersMiddleware();

// middleware 3
//app.Use(async (HttpContext context, RequestDelegate next) =>
//{
//    await context.Response.WriteAsync(Directory.GetCurrentDirectory() + "\r\n");
//    await next(context);
//});

// IConfiguration configuration = new ConfigurationBuilder()
//     .SetBasePath(Directory.GetCurrentDirectory())
//     .AddJsonFile("appsettings.json")
//     .Build();

// var env = configuration.GetValue<string>("ConnectionStrings");

// middleware check computer device
//app.Use(async (HttpContext context, RequestDelegate next) =>
//{
//    var envDevice = builder.Configuration.GetSection("laptop");
//    if (Convert.ToBoolean(envDevice["mobile_tablet"]))
//    {

//        await context.Response.WriteAsync(envDevice["mobile_tablet"]! + "\r\n");
//        await context.Response.WriteAsync("laptop env");
//    }
//    else
//    {
//        await context.Response.WriteAsync(envDevice["mobile_tablet"]! + "\r\n");
//        await context.Response.WriteAsync("not laptop env");
//    }

//});


//app.Run(async context =>
//    {
//        await context.Response.WriteAsync($"Request received at {context.Request.Path}");
//    }
//);

app.Run();
