using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CourWork2024.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<CourWork2024Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("default") ?? throw new InvalidOperationException("Connection string 'CourWork2024Context' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();
//builder.Services.AddDbContext<>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("default")));
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
    pattern: "{controller=Cars}/{action=Index}/{id?}");

app.Run();
