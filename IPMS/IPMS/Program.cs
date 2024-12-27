using BlazorBootstrap;
using IPMS.Data;
using IPMS.Interfaces;
using IPMS.Repositories;
using IPMS.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddTransient<IStockManagementRepository, StockManagementRepository>();
builder.Services.AddTransient<IProductManagementRepository,ProductManagementRepository>();
builder.Services.AddTransient<IBillOfMatrialsManagementRepository, BillOfMatrialsManagementRepository> ();
builder.Services.AddScoped<StockService, StockService>();
builder.Services.AddScoped<ProductService, ProductService>();
builder.Services.AddBlazorBootstrap();
builder.Services.AddDbContext<ApplicationDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
