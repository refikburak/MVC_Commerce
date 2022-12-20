using Microsoft.EntityFrameworkCore;
using MVC_Commerce.Data;
using MVC_Commerce.Data.Interfaces;
using MVC_Commerce.Data.Services;
using MVC_Commerce.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//DbContext Configuration
builder.Services.AddDbContext<CommerceContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")));
//Service Configuration
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IProductService, ProductService>();

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
    pattern: "{controller=Product}/{action=Index}/{id?}");

//Seed Database
CommerceDbInitializer.Seed(app);

app.Run();
