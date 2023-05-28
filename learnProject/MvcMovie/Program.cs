using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
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


// Logging

// Serilog
using var log = new LoggerConfiguration()
    .WriteTo.Console(outputTemplate:
        "[{Timestamp:HH:mm:ss} {fileName}:{lineNum} {Level:u3}] {Message:lj} {NewLine}{Exception} ")
    .CreateLogger();

Log.Logger = log;



// need refactor
Dictionary<string, string?> connectStringsCollection = new Dictionary<string, string?>();
connectStringsCollection.Add("laptopMvcMovieContext", builder.Configuration.GetConnectionString("MSSQL"));
connectStringsCollection.Add("laptopProductionMvcMovieContext", builder.Configuration.GetConnectionString("MSSQL"));
connectStringsCollection.Add("desktopMvcMovieContext", builder.Configuration.GetConnectionString("MSSQL"));
connectStringsCollection.Add("desktopProductionMvcMovieContext", builder.Configuration.GetConnectionString("MSSQL"));


var computerType = builder.Configuration.GetSection("laptop");
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

app.UseAuthorization();

app.MapControllerRoute(
   name: "default",
   pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
