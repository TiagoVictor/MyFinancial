using Microsoft.EntityFrameworkCore;
using MyFinancial.Data.Context;
using MyFinancial.Data.Repository;
using MyFinancial.Data.Repository.Interface;
using MyFinancial.Service;
using MyFinancial.Service.Interface;
using static MyFinancial.AppSettings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.Configure<ConnectionStrings>(builder.Configuration.GetSection("ConnectionStrings"));
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("Financial")));

builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IIncomeRepository, IncomeRepository>();

builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IIncomeService, IncomeService>();

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
    pattern: "{controller=Home}/{action=Login}/{id?}");

app.Run();
