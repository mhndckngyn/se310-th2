using Microsoft.EntityFrameworkCore;
using se310_th2.Context;
using se310_th2.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("MyDbContext");
builder.Services.AddDbContext<MyDbContext>(x => x.UseSqlServer(connectionString));

// Dependency Injection container: When ILoaiSpRepository is needed, it provides an instance of LoaiSpRepository
builder.Services.AddScoped<ILoaiSpRepository, LoaiSpRepository>();

builder.Services.AddSession();

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

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Access}/{action=LogIn}/{id?}");

app.Run();