using Microsoft.EntityFrameworkCore;
using System.Configuration;
using WebApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddMvcCore(op => op.EnableEndpointRouting = false);


builder.Services.AddControllers();
builder.Services.AddDbContext<StoreDbContext>(opt =>
    opt.UseInMemoryDatabase("StoreDb"));


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

app.UseCors("AllowSpecificOrigin");

app.UseRouting();

app.UseAuthorization();
app.UseMvcWithDefaultRoute();
app.MapRazorPages();

app.Run();
